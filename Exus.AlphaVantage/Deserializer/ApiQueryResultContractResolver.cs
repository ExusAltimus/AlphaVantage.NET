using Exus.AlphaVantage.Deserializer.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Exus.AlphaVantage
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

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);
            return property;
        }

        protected override JsonObjectContract CreateObjectContract(Type objectType)
        {
            JsonObjectContract contract = base.CreateObjectContract(objectType);

            var resolved = _serviceProvider?.GetService(typeof(ApiQueryResultJsonConverter));
            var converter = (ApiQueryResultJsonConverter)(resolved ?? new ApiQueryResultJsonConverter());

            contract.Converter = converter;
            return contract;
        }


        protected override JsonContract CreateContract(Type objectType)
        {
            JsonContract contract = base.CreateContract(objectType);
            return contract;
        }

        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var serializableMembers = base.GetSerializableMembers(objectType);
            return serializableMembers;
        }
    }
}
