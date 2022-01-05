using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GovInformer.Application.Adapters.SenateGov
{

    public sealed class SenatorResponse
    {
        [XmlElement("member_full")]
        public string MemberFull { get; set; }

        [XmlElement("last_name")]
        public string LastName { get; set; }

        [XmlElement("first_name")]
        public string FirstName { get; set; }

        [XmlElement("party")]
        public string Party { get; set; }

        [XmlElement("state")]
        public string State { get; set; }

        [XmlElement("address")]
        public string Address { get; set; }

        [XmlElement("phone")]
        public string Phone { get; set; }

        [XmlElement("email")]
        public string Email { get; set; }

        [XmlElement("website")]
        public string Website { get; set; }

        [XmlElement("class")]
        public string SenatorClass { get; set; }

        [XmlElement("bioguide_id")]
        public string SenatorId { get; set; }
    }


    [XmlRoot("contact_information")]
    public sealed class SenateGovResponse
    {

        [XmlElement("member")]
        public List<SenatorResponse> Senators { get; set; }

        [XmlElement("last_updated")]
        public string LastUpdated { get; set; }
    }



}
