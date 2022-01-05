using GovInformer.Application.Adapters.TheUnitedStatesIO;
using GovInformer.Models.Common;
using GovInformer.Models.Congress;
using GovInformer.Models.Congress.Representatives;
using GovInformer.Models.Congress.Senators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GovInformer.Application.Congress
{
    public sealed class CongressGatherer
    {
        public async Task<List<Senator>> GatherAllSenators()
        {
            var result = await new TheUnitedStatesIOAdapter().GetAllCurrentLegislators();

            return
                result.Select(leg =>
                    new Senator
                    {
                        GovTrackID = leg.IDs.GovTrackID.ToString(),
                        BioGuideID = leg.IDs.BioGuideID.ToString(),
                        FirstName = leg.Name.FirstName,
                        LastName = leg.Name.LastName,
                        Birthday = leg.Bio.Birthday,
                        PhoneNumber = leg.Terms.Last().PhoneNumber,
                        Website = leg.Terms.Last().SenatorSite,
                        CongressType = CongressType.Parse(leg.Terms.Last().CongressType),
                        PoliticalParty = PoliticalParty.Parse(leg.Terms.Last().PoliticalParty),
                        StateTerritory = StateTerritory.Parse(leg.Terms.Last().StateTerritory),
                        SenateClass = SenateClass.Parse(leg.Terms.Last().SenatorClass),
                        TermStart = leg.Terms.Last().TermStart,
                        TermEnd = leg.Terms.Last().TermEnd,
                        YearsOfSenatorExperience = leg.Terms.Where(term => CongressType.Parse(leg.Terms.Last().CongressType) == CongressType.Senator).Select(term => (int)((term.TermEnd - term.TermStart).TotalDays / 365.2425)).ToList().Sum(),
                    }
                ).Where(leg => leg.CongressType == CongressType.Senator).ToList();
        }

        public async Task<List<Representative>> GatherAllRepresentatives()
        {
            var result = await new TheUnitedStatesIOAdapter().GetAllCurrentLegislators();

            return
                result.Select(leg =>
                    new Representative
                    {
                        GovTrackID = leg.IDs.GovTrackID.ToString(),
                        BioGuideID = leg.IDs.BioGuideID.ToString(),
                        FirstName = leg.Name.FirstName,
                        LastName = leg.Name.LastName,
                        Birthday = leg.Bio.Birthday,
                        PhoneNumber = leg.Terms.Last().PhoneNumber,
                        Website = leg.Terms.Last().SenatorSite,
                        CongressType = CongressType.Parse(leg.Terms.Last().CongressType),
                        PoliticalParty = PoliticalParty.Parse(leg.Terms.Last().PoliticalParty),
                        StateTerritory = StateTerritory.Parse(leg.Terms.Last().StateTerritory),
                        District = leg.Terms.Last().District,
                        TermStart = leg.Terms.Last().TermStart,
                        TermEnd = leg.Terms.Last().TermEnd,
                        YearsOfRepresentativeExperience = leg.Terms.Where(term => CongressType.Parse(leg.Terms.Last().CongressType) == CongressType.Representative).Select(term => (int)((term.TermEnd - term.TermStart).TotalDays / 365.2425)).ToList().Sum(),
                    }
                ).Where(leg => leg.CongressType == CongressType.Representative).ToList();
        }

        public async Task<List<Models.Congress.Committees.Committee>> GatherAllCommittees()
        {
            var result = await new TheUnitedStatesIOAdapter().GetAllCurrentCommittees();

            return
                result.Select(comm =>
                    new Models.Congress.Committees.Committee
                    {
                        ID = comm.ID,
                        CongressType = CongressType.Parse(comm.CongressType),
                        Name = comm.Name,
                        Website = comm.Website,
                        MinorityWebsite = comm.MinorityWebsite,
                        Jurisdiction = comm.Jurisdiction,
                        PhoneNumber = comm.PhoneNumber,
                        Address = comm.Address,
                        SubCommittees = comm.SubCommittees?.Select(scomm => new Models.Congress.Committees.SubCommittees
                        {
                            ID = scomm.ID,
                            Address = scomm.Address,
                            Phone = scomm.PhoneNumber,
                            Name = scomm.Name,
                        }).ToList()
                    }
                ).ToList();
        }

        public async Task<Dictionary<string, HashSet<Models.Congress.Committees.CommitteeMembership>>> GatherAllCommitteeMembership()
        {
            var result = await new TheUnitedStatesIOAdapter().GetAllCurrentCommitteeMembership();

            var ret = new Dictionary<string, HashSet<Models.Congress.Committees.CommitteeMembership>>();
            foreach (var kvp in result)
            {
                var committeeId = kvp.Key;
                var set = new HashSet<Models.Congress.Committees.CommitteeMembership>();
                if (kvp.Value == null)
                {
                    ret.Add(committeeId, set);
                    continue;
                }

                foreach (var membership in kvp.Value)
                {
                    set.Add(new Models.Congress.Committees.CommitteeMembership
                    {
                        BioGuideID = membership.BioGuideID,
                        CommitteeRank = membership.CommitteeRank,
                        MajorityOrMinority = membership.MajorityOrMinority,
                        MemberName = membership.MemberName
                    });
                }

                ret.Add(committeeId, set);
            }

            return ret;
        }

        public async Task<List<Representative>> GatherCommitteeMembershipForLegislators()
        {
            var committees = await GatherAllCommittees();
            var committeeMembership = await GatherAllCommitteeMembership();
            var representatives = await GatherAllRepresentatives();


            var committeeIdMap = new Dictionary<string, Models.Congress.Committees.Committee>();
            /* BioId to Leg */
            var repMap = new Dictionary<string, Representative>();

            foreach (var comm in committees)
            {
                committeeIdMap.Add(comm.ID, comm);
            }

            foreach (var rep in representatives)
            {
                repMap.Add(rep.BioGuideID, rep);
            }

            var dict = new Dictionary<string, HashSet<Models.Congress.Committees.Committee>>();
            foreach (var kvp in committeeIdMap)
            {
                var committeeId = kvp.Key;

                /* bioId to SubComm */
                var subCommittess = new Dictionary<string, HashSet<Models.Congress.Committees.SubCommittees>>();
                if (kvp.Value.SubCommittees != null)
                {
                    foreach (var subcomm in kvp.Value.SubCommittees)
                    {
                        var subCommId = committeeId + subcomm.ID;
                        if (committeeMembership.ContainsKey(subCommId))
                        {
                            foreach (var subCommMember in committeeMembership[subCommId])
                            {
                                if (!subCommittess.TryAdd(subCommMember.BioGuideID, new HashSet<Models.Congress.Committees.SubCommittees>() { subcomm }))
                                {
                                    //There already exists a bioId to to Set, lets just add the element.
                                    subCommittess[subCommMember.BioGuideID].Add(subcomm);
                                }
                            }
                        }
                    }
                }

                if (!committeeMembership.ContainsKey(committeeId))
                {
                    throw new InvalidOperationException("Invalid assumption that committeeId is always in committeeMembership");
                }

                foreach (var member in committeeMembership[committeeId])
                {
                    var bioGuideId = member.BioGuideID;
                    var addCommittee = new Models.Congress.Committees.Committee
                    {
                        CommitteeRank = member.CommitteeRank,
                        ID = committeeId,
                        CongressType = kvp.Value.CongressType,
                        Name = kvp.Value.Name,
                        Website = kvp.Value.Website,
                        MinorityWebsite = kvp.Value.MinorityWebsite,
                        Jurisdiction = kvp.Value.Jurisdiction,
                        PhoneNumber = kvp.Value.PhoneNumber,
                        Address = kvp.Value.Address,
                        SubCommittees = subCommittess.ContainsKey(member.BioGuideID) ? subCommittess[member.BioGuideID].ToList() : null,
                    };

                    if (dict.TryAdd(bioGuideId, new HashSet<Models.Congress.Committees.Committee> { addCommittee }))
                    {
                        //There already exists a bioId to to Set, lets just add the element.
                        dict[bioGuideId].Add(addCommittee);
                    }
                }
            }


            return repMap.Select(rep => new Representative
            {
                GovTrackID = rep.Value.GovTrackID,
                BioGuideID = rep.Value.BioGuideID,
                FirstName = rep.Value.FirstName,
                LastName = rep.Value.LastName,
                Birthday = rep.Value.Birthday,
                PhoneNumber = rep.Value.PhoneNumber,
                Website = rep.Value.Website,
                CongressType = rep.Value.CongressType,
                PoliticalParty = rep.Value.PoliticalParty,
                StateTerritory = rep.Value.StateTerritory,
                TermStart = rep.Value.TermStart,
                TermEnd = rep.Value.TermEnd,
                YearsOfExperience = rep.Value.YearsOfExperience,
                YearsOfRepresentativeExperience = rep.Value.YearsOfRepresentativeExperience,
                YearsOfSenatorExperience = rep.Value.YearsOfSenatorExperience,
                Committees = dict.ContainsKey(rep.Value.BioGuideID) ? dict[rep.Value.BioGuideID].ToList() : null,
            }).ToList();
        }
    }
}
