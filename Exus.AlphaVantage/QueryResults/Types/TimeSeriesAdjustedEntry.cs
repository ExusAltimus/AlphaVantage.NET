using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Exus.AlphaVantage.QueryResults.Types
{
    //https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=MSFT&apikey=demo
    [DataContract]
    public class TimeSeriesAdjustedEntry
    {
        [DataMember(Name = "1. open")]
        public double Open { get; set; }
        [DataMember(Name = "2. high")]
        public double High { get; set; }
        [DataMember(Name = "3. low")]
        public double Low { get; set; }
        [DataMember(Name = "4. close")]
        public double Close { get; set; }
        [DataMember(Name = "5. adjusted close")]
        public double AdjustedClose { get; set; }
        [DataMember(Name = "6. volume")]
        public int Volume { get; set; }
        [DataMember(Name = "7. dividend amount")]
        public double DividendAmount { get; set; }
        [DataMember(Name = "8. split coefficient", IsRequired = false)]
        public double SplitCoefficient { get; set; }
    }
}
