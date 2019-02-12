using Exus.AlphaVantage.Core.Deserializer.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Exus.AlphaVantage.Core
{
    public class ApiQueryResultContractResolver : DefaultContractResolver, IApiQueryResultContractResolver
    {
        private readonly IServiceProvider _serviceProvider;

        public ApiQueryResultContractResolver()
        {

        }

        public ApiQueryResultContractResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            JsonObjectContract contract = base.CreateObjectContract(objectType);

            if (objectType.IsClass && objectType != typeof(object))
            {
                var resolved = _serviceProvider?.GetService(typeof(ApiQueryResultJsonConverter));
                var converter = (ApiQueryResultJsonConverter)(resolved ?? new ApiQueryResultJsonConverter());

                contract.Converter = converter;
            }

            return contract;
        }
    }
}
