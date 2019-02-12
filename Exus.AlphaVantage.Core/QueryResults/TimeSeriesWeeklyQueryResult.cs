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
    public class TimeSeriesWeeklyQueryResult : ApiQueryResult
    {
        [DataMember(Name = "Meta Data")]
        public TimeSeriesMetaData MetaData { get; set; }

        [DataMember(Name = "Weekly Time Series")]
        public Dictionary<DateTime, TimeSeriesEntry> TimeSeries { get; set; }
    }
}
