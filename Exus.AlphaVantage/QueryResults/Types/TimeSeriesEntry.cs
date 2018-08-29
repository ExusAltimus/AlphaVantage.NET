using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Exus.AlphaVantage.QueryResults.Types
{
    //https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=MSFT&apikey=demo
    [DataContract]
    public class TimeSeriesEntry
    {
        [DataMember(Name = "1. open")]
        public double Open { get; set; }
        [DataMember(Name = "2. high")]
        public double High { get; set; }
        [DataMember(Name = "3. low")]
        public double Low { get; set; }
        [DataMember(Name = "4. close")]
        public double Close { get; set; }
        [DataMember(Name = "5. volume")]
        public int Volume { get; set; }
    }

}
