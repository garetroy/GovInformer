using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace GovInformer.Application.Adapters
{
    internal class BaseAdapter
    {
        protected async Task<T> Get<T>(string url, Func<Stream, Task<T>> processFunc)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            using Stream stream = response.GetResponseStream();
            return await processFunc(stream);
        }
    }
}
