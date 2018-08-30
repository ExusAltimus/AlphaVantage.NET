
using Exus.AlphaVantage.Deserializer;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exus.AlphaVantage
{
    /// <summary>
    /// Default implementation
    /// </summary>
    public class ApiQuerier : IApiQuerier
    {
        private readonly ApiQuerierSettings _options;
        private readonly IApiWebClient _webClient;

        public ApiQuerier(string apiKey)
        {
            _webClient = new ApiWebClient();
            _options = new ApiQuerierSettings()
            {
                ApiKey = apiKey
            };
        }

        public ApiQuerier(IOptions<ApiQuerierSettings> options)
        {
            _webClient = new ApiWebClient();
            _options = options.Value;
        }

        public ApiQuerier(IApiWebClient webClient, IOptions<ApiQuerierSettings> options)
        {
            _webClient = webClient;
            _options = options.Value;
        }

        public async Task<TApiQueryResult> Query<TApiQueryResult>(IApiQuery<TApiQueryResult> query)
        {
            if (String.IsNullOrEmpty(query.ApiKey))
                query.ApiKey = _options.ApiKey;

            if (String.IsNullOrEmpty(query.ApiKey))
                throw new Exception("Api key required.");

            return await _webClient.Query(query);
        }
    }
}
