using Exus.AlphaVantage.Core.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Exus.AlphaVantage.Core
{
    /// <summary>
    /// Property converter that allows multiple DataMember names to be serialized to a single property using the [DataMemberName(name)] attribute
    /// </summary>
    public class ApiQueryResultJsonConverter : JsonConverter
    {

        public override bool CanRead => true;
        public override bool CanWrite => false;


        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsClass;
        }
        
        public virtual IList<string> GetJsonPropertyNames(PropertyInfo property)
        {
            var names = new List<string>();

            names.AddRange(property.GetCustomAttributes<DataMemberNameAttribute>().Select(a => a.Name));

            var jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyAttribute>();
            if (jsonPropertyAttribute != null)
                names.Add(property.GetCustomAttribute<JsonPropertyAttribute>().PropertyName);

            var dataMemberAttribute = property.GetCustomAttribute<DataMemberAttribute>();
            if (dataMemberAttribute != null)
                names.Add(property.GetCustomAttribute<DataMemberAttribute>().Name);

            return names;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object instance = objectType.GetConstructor(Type.EmptyTypes).Invoke(null);
            PropertyInfo[] writeableProperties = objectType.GetProperties().Where(p => p.CanWrite).ToArray();

            JObject jo = JObject.Load(reader);

            foreach (var jp in jo.Properties())
            {
                foreach (var prop in writeableProperties)
                {
                    var names = GetJsonPropertyNames(prop);
                    //If any names match the json property name
                    if (names.Any(name => string.Equals(jp.Name, name, StringComparison.OrdinalIgnoreCase)))
                    {
                        prop.SetValue(instance, jp.Value.ToObject(prop.PropertyType, serializer));
                    }
                }

            }

            return instance;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
