using MasGlobalTech.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasGlobalTech.Helpers
{
    public class HttpClientUtility : IHttpClientUtility
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IOptions<ExternalResources> _appSettings;

        public HttpClientUtility(IHttpClientFactory clientFactory, IOptions<ExternalResources> appSettings)
        {
            _clientFactory = clientFactory;
            _appSettings = appSettings;
        }

        public async Task<IEnumerable<T>> GetListAsync<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content
                    .ReadAsAsync<IEnumerable<T>>();
            }
            else
            {
                return Enumerable.Empty<T>();
            }
        }
    }
}
