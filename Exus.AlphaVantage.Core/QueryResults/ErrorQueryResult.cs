using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Exus.AlphaVantage.Core.QueryResults
{
    [DataContract]
    public class ErrorQueryResult : IApiQueryResult
    {

        [DataMember(Name = "Error Message")]
        public string ErrorMessage { get; set; }

        public ErrorQueryResult()
        {

        }
    }
}
