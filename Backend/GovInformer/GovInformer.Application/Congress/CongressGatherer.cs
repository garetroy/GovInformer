using GovInformer.Application.Adapters.TheUnitedStatesIO;
using GovInformer.Models.Common;
using GovInformer.Models.Congress;
using GovInformer.Models.Congress.Committees;
using GovInformer.Models.Congress.Representatives;
using GovInformer.Models.Congress.Senators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace GovInformer.Application.Congress
{
    public sealed class CongressGatherer
    {
        public async Task<HashSet<Senator>> GatherAllSenators()
        {
            return await Gather(System.Reflection.MethodBase.GetCurrentMethod().Name, async () =>
            {
                var legislators = await new TheUnitedStatesIOAdapter().GetAllCurrentLegislators();

                var sentors = legislators.Select(leg =>
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
                ).Where(leg => leg.CongressType == CongressType.Senator).ToDictionary(leg => leg.BioGuideID);

                await GatherCommitteeMembershipForLegislators(sentors);
                return sentors.Values.ToHashSet();
            });
        }

        public async Task<HashSet<Representative>> GatherAllRepresentatives()
        {
            return await Gather(System.Reflection.MethodBase.GetCurrentMethod().Name, async () =>
            {
                var legislators = await new TheUnitedStatesIOAdapter().GetAllCurrentLegislators();

                var representatives = legislators.Select(leg =>
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
                ).Where(leg => leg.CongressType == CongressType.Representative).ToDictionary(leg => leg.BioGuideID);

                await GatherCommitteeMembershipForLegislators(representatives);

                return representatives.Values.ToHashSet();
            });
        }

        public async Task<HashSet<Committee>> GatherAllCommittees()
        {
            return await Gather(System.Reflection.MethodBase.GetCurrentMethod().Name, async () =>
            {
                var committees = await new TheUnitedStatesIOAdapter().GetAllCurrentCommittees();

                return
                    committees.Select(comm =>
                        new Committee
                        {
                            ID = comm.ID,
                            CongressType = CongressType.Parse(comm.CongressType),
                            Name = comm.Name,
                            Website = comm.Website,
                            MinorityWebsite = comm.MinorityWebsite,
                            Jurisdiction = comm.Jurisdiction,
                            PhoneNumber = comm.PhoneNumber,
                            Address = comm.Address,
                            SubCommittees = comm.SubCommittees?.Select(scomm => new SubCommittees
                            {
                                ID = comm.ID + scomm.ID,
                                Address = scomm.Address,
                                Phone = scomm.PhoneNumber,
                                Name = scomm.Name,
                            }).ToHashSet()
                        }
                    ).ToHashSet();
            });
        }

        public async Task<Dictionary<string, HashSet<CommitteeMembership>>> GatherAllCommitteeMembership()
        {
            return await Gather(System.Reflection.MethodBase.GetCurrentMethod().Name, async () =>
            {
                var result = await new TheUnitedStatesIOAdapter().GetAllCurrentCommitteeMembership();

                var ret = new Dictionary<string, HashSet<CommitteeMembership>>();
                foreach (var kvp in result)
                {
                    var committeeId = kvp.Key;
                    var set = new HashSet<CommitteeMembership>();
                    if (kvp.Value == null)
                    {
                        ret.Add(committeeId, set);
                        continue;
                    }

                    foreach (var membership in kvp.Value)
                    {
                        set.Add(new CommitteeMembership
                        {
                            BioGuideID = membership.BioGuideID,
                            CommitteeRank = membership.CommitteeRank,
                            Majority = membership.MajorityOrMinority.ToLower() == "majority",
                            MemberName = membership.MemberName
                        });
                    }

                    ret.Add(committeeId, set);
                }

                return ret;
            });
        }


        private async Task<Dictionary<string, Committee>> GatherAllCommitteesDict()
        {
            return await Gather(System.Reflection.MethodBase.GetCurrentMethod().Name, async () =>
            {
                var result = await new TheUnitedStatesIOAdapter().GetAllCurrentCommittees();

                return
                    result.Select(comm =>
                        new Committee
                        {
                            ID = comm.ID,
                            CongressType = CongressType.Parse(comm.CongressType),
                            Name = comm.Name,
                            Website = comm.Website,
                            MinorityWebsite = comm.MinorityWebsite,
                            Jurisdiction = comm.Jurisdiction,
                            PhoneNumber = comm.PhoneNumber,
                            Address = comm.Address,
                            SubCommittees = comm.SubCommittees?.Select(scomm => new SubCommittees
                            {
                                ID = comm.ID + scomm.ID,
                                Address = scomm.Address,
                                Phone = scomm.PhoneNumber,
                                Name = scomm.Name,
                            }).ToHashSet()
                        }
                    ).ToDictionary(comm => comm.ID);
            });
        }


        private async Task GatherCommitteeMembershipForLegislators<T>(Dictionary<string, T> legislators) where T : Legislator
        {
            // CommitteeID -> Committee
            var committees = await GatherAllCommitteesDict();
            var committeeMembership = await GatherAllCommitteeMembership();

            // LegislatorBioID -> Set<Committees> (committees legislator is in)
            var legislatorsCommittees = new Dictionary<string, HashSet<Committee>>();
            foreach (var kvp in committees)
            {
                var committeeId = kvp.Key;
                var committee = kvp.Value;

                // LegislatorBioID -> Set<SubCommitees> (subcommittees legislator is in)
                var subCommittess = new Dictionary<string, HashSet<SubCommittees>>();
                if (committee.SubCommittees != null)
                {
                    foreach (var subcomm in committee.SubCommittees)
                    {
                        var subCommId = committeeId + subcomm.ID;
                        if (committeeMembership.ContainsKey(subCommId))
                        {
                            foreach (var subCommMember in committeeMembership[subCommId])
                            {
                                if (!subCommittess.TryAdd(subCommMember.BioGuideID, new HashSet<SubCommittees>() { subcomm }))
                                {
                                    //There already exists a bioId within the Set, lets just add the element to that set
                                    subCommittess[subCommMember.BioGuideID].Add(subcomm);
                                }
                            }
                        }
                    }
                }

                if (!committeeMembership.ContainsKey(committeeId))
                {
                    //We need proper error handling here...
                    throw new InvalidOperationException("Invalid assumption that committeeId is always in committeeMembership");
                }

                foreach (var member in committeeMembership[committeeId])
                {
                    var bioGuideId = member.BioGuideID;
                    committee.SubCommittees = subCommittess.ContainsKey(member.BioGuideID) ? subCommittess[member.BioGuideID] : null;
                    committee.LegislatorsRulingParty = member.Majority;

                    if (legislatorsCommittees.TryAdd(bioGuideId, new HashSet<Committee> { committee }))
                    {
                        //There already exists a bioId within the Set, lets just add the element to that set
                        legislatorsCommittees[bioGuideId].Add(committee);
                    }
                }
            }

            foreach (var kvp in legislators)
            {
                var leg = kvp.Value;
                if (legislatorsCommittees.ContainsKey(leg.BioGuideID))
                {

                    leg.Committees = legislatorsCommittees[leg.BioGuideID];
                }
            }
        }

        private CacheItemPolicy GenerateCachePolicy()
        {
            return new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddMinutes(MinutesToLive) };
        }

        private async Task<T> Gather<T>(string cacheName, Func<Task<T>> generateObject)
        {
            if (MemoryCache.Default[cacheName] is T result)
            {
                return result;
            }

            result = await generateObject();

            MemoryCache.Default.Set(cacheName, result, GenerateCachePolicy());
            return result;
        }


        private readonly int MinutesToLive = 5;
    }
}
