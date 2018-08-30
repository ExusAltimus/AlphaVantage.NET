using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Exus.AlphaVantage.Deserializer;

namespace Exus.AlphaVantage
{
    /// <summary>
    /// Default implementation
    /// </summary>
    public class ApiWebClient : IApiWebClient
    { 
        public const string QUERY_URL = "https://www.alphavantage.co/query";

        private readonly IApiQueryResultDeserializer<string> _deserializer;

        public ApiWebClient()
        {
            _deserializer = new ApiQueryResultDeserializer();
        }

        public ApiWebClient(IApiQueryResultDeserializer<string> deserializer)
        {
            _deserializer = deserializer;
        }

        public async Task<TApiQueryResult> Query<TApiQueryResult>(IApiQuery<TApiQueryResult> query)
        {
            using (var webClient = new System.Net.WebClient())
            {
                webClient.QueryString = query.Parameters.Aggregate(new NameValueCollection(),
                            (seed, current) => {
                                seed.Add(current.Key, current.Value);
                                return seed;
                            });
                var json = await webClient.DownloadStringTaskAsync(QUERY_URL);
                return _deserializer.Deserialize<TApiQueryResult>(json);
            }    
        }
    }
}
