using System;
using System.IO;
using System.Net;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace GovInformer.Application.Adapters
{
    internal class BaseAdapter
    {
        protected async Task<T> Get<T>(string url, Func<Stream, Task<T>> processFunc)
        {
            if (MemoryCache.Default[url] is T result)
            {
                return result;
            }

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            using Stream stream = response.GetResponseStream();

            result = await processFunc(stream);

            var policy = new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddMinutes(MinutesToLive) };
            MemoryCache.Default.Set(url, result, policy);

            return result;
        }

        private readonly int MinutesToLive = 10;
    }
}
