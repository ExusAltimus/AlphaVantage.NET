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
    public class ApiWebClient : IApiWebClient
    { 
        private readonly IApiQueryResultDeserializer _deserializer;

        public ApiWebClient()
        {
            _deserializer = new ApiQueryResultDeserializer();
        }

        public ApiWebClient(IApiQueryResultDeserializer deserializer)
        {
            _deserializer = deserializer;
        }

        public const string QUERY_URL = "https://www.alphavantage.co/query";
        
        public async Task<TApiQueryResult> Query<TApiQueryResult>(IApiQuery<TApiQueryResult> query)
        {
            TApiQueryResult result;
            using (var webClient = new System.Net.WebClient())
            {
                webClient.QueryString = query.Parameters.Aggregate(new NameValueCollection(),
                            (seed, current) => {
                                seed.Add(current.Key, current.Value);
                                return seed;
                            });
          
                var json = await webClient.DownloadStringTaskAsync(QUERY_URL);
                result = _deserializer.Deserialize<TApiQueryResult>(json);      
            }

            return result;
        }
    }
}
