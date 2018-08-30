using Exus.AlphaVantage.Deserializer.Interfaces;
using Exus.AlphaVantage.QueryResults;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Exus.AlphaVantage.Deserializer
{
    public class ApiQueryResultDeserializer : IApiQueryResultDeserializer<Stream>
    {
        private readonly IServiceProvider _serviceProvider;

        public ApiQueryResultDeserializer()
        {
        }

        public ApiQueryResultDeserializer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }


        public TApiQueryResult Deserialize<TApiQueryResult>(Stream stream)
        {
            var resolved = _serviceProvider?.GetService(typeof(IApiQueryResultContractResolver));
            var contractResolver = (IApiQueryResultContractResolver)(resolved ?? new ApiQueryResultContractResolver(_serviceProvider));


            var reader = new StreamReader(stream);
            var jsonReader = new JsonTextReader(reader);
            var serializer = new JsonSerializer();

            serializer.ContractResolver = contractResolver;
            var jObject = serializer.Deserialize(jsonReader);
            
            if (((JObject)jObject).Properties().Any(p => p.Name == "Error Message"))
            {
                var errorResult = ((JObject)jObject).ToObject<ErrorQueryResult>();
                if (!String.IsNullOrEmpty(errorResult.ErrorMessage))
                    throw new ApiQueryErrorException(errorResult.ErrorMessage);
            }
            else if (typeof(TApiQueryResult) != typeof(object))
            {
                var result = ((JObject)jObject).ToObject<TApiQueryResult>();
                return result;
            }

            return (TApiQueryResult)jObject;
        }
    }
}
