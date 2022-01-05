using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GovInformer.Application.Adapters.SenateGov
{
    internal sealed class SenateGovAdapter
    {
        public async Task<SenateGovResponse> GetAllSenators()
        {
            var url = "https://www.senate.gov/general/contact_information/senators_cfm.xml";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(SenateGovResponse));
                return (SenateGovResponse)serializer.Deserialize(reader);
            }
        }
    }
}
