using Exus.AlphaVantage.Attributes;
using Exus.AlphaVantage.QueryResults.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Exus.AlphaVantage.QueryResults
{
    [DataContract]
    public class TimeSeriesWeeklyQueryResult : ApiQueryResult
    {
        [DataMember(Name = "Meta Data")]
        public TimeSeriesMetaData_2 MetaData { get; set; }

        [DataMember(Name = "Weekly Time Series")]
        public Dictionary<DateTime, TimeSeriesEntry> TimeSeries { get; set; }
    }
}
