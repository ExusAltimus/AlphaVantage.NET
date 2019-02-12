using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Exus.AlphaVantage.Core.Deserializer;
using Newtonsoft.Json;
using System.IO;

namespace Exus.AlphaVantage.Core
{
    /// <summary>
    /// Default implementation
    /// </summary>
    public class ApiWebClient : IApiWebClient
    { 
        public const string QUERY_URL = "https://www.alphavantage.co/query";

        private readonly IApiQueryResultDeserializer<Stream> _deserializer;

        public ApiWebClient()
        {
            _deserializer = new ApiQueryResultDeserializer();
        }

        public ApiWebClient(IApiQueryResultDeserializer<Stream> deserializer)
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
                using (var stream = await webClient.OpenReadTaskAsync(QUERY_URL))
                {
                    var result = _deserializer.Deserialize<TApiQueryResult>(stream);

                    return result;
                }
            }    
        }
    }
}
