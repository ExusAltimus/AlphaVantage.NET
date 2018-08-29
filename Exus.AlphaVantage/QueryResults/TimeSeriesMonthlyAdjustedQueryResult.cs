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
    public class TimeSeriesMonthlyAdjustedQueryResult : ApiQueryResult
    {
        [DataMember(Name = "Meta Data")]
        public TimeSeriesMetaData_2 MetaData { get; set; }

        [DataMember(Name = "Monthly Adjusted Time Series")]
        public Dictionary<DateTime, TimeSeriesAdjustedEntry> TimeSeries { get; set; }
    }
}
