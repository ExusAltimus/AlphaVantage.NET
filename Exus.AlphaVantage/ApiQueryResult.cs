using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Exus.AlphaVantage.QueryResults
{
    [DataContract]
    public class ApiQueryResult : IApiQueryResult
    {
        [DataMember(Name = "Meta Data")]
        public Dictionary<string, string> MetaDataDictionary { get; set; }

        public ApiQueryResult()
        {

        }
    }
}
