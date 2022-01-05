using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GovInformer.Application.Adapters.SenateGov
{
    internal sealed class SenateGovAdapter : BaseAdapter
    {
        public async Task<SenateGovResponse> GetAllSenators()
        {
            var url = "https://www.senate.gov/general/contact_information/senators_cfm.xml";

            return await Get(url, streamReader =>
            {
                var serializer = new XmlSerializer(typeof(SenateGovResponse));
                return Task.FromResult((SenateGovResponse)serializer.Deserialize(streamReader));
            });
        }
    }
}
