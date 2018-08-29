using Exus.AlphaVantage.Deserializer.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Deserializer
{
    public class ApiQueryResultDeserializer : IApiQueryResultDeserializer
    {
        private readonly IServiceProvider _serviceProvider;

        public ApiQueryResultDeserializer()
        {
        }

        public ApiQueryResultDeserializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TApiQueryResult Deserialize<TApiQueryResult>(string json)
        {
            var resolved = _serviceProvider?.GetService(typeof(IApiQueryResultContractResolver));
            var contractResolver = (IApiQueryResultContractResolver)(resolved ?? new ApiQueryResultContractResolver(_serviceProvider));
            var queryResultType = typeof(TApiQueryResult);

            if (queryResultType != typeof(object))
            {
                return JsonConvert.DeserializeObject<TApiQueryResult>(json, new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver
                });
            }
            else
            {
                return JsonConvert.DeserializeObject<TApiQueryResult>(json);
            }
        }
    }
}
