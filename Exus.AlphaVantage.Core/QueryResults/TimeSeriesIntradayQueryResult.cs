using Exus.AlphaVantage.Core.Attributes;
using Exus.AlphaVantage.Core.QueryResults.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Exus.AlphaVantage.Core.QueryResults
{
    [DataContract]
    public class TimeSeriesIntradayQueryResult : ApiQueryResult
    {
        [DataMember(Name = "Meta Data")]
        public TimeSeriesMetaData MetaData { get; set; }

        [DataMemberName("Time Series (1min)")]
        [DataMemberName("Time Series (5min)")]
        [DataMemberName("Time Series (15min)")]
        [DataMemberName("Time Series (30min)")]
        [DataMemberName("Time Series (60min)")]
        [DataMember]
        public Dictionary<DateTime, TimeSeriesEntry> TimeSeries { get; set; }

    }
}
