using Exus.AlphaVantage.Attributes;
using Exus.AlphaVantage.Queries.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exus.AlphaVantage.Queries
{
    public class TimeSeriesDailyAdjustedQuery : ApiQuery<QueryResults.TimeSeriesDailyAdjustedQueryResult>
    {
        public TimeSeriesDailyAdjustedQuery()
        {
            this.Function = ApiFunction.TIME_SERIES_DAILY_ADJUSTED;
        }

        [ApiParameter("symbol")]
        public string Symbol {
            get { return GetParameter(); }
            set { SetParameter(value); }
        }

        [ApiParameter("outputsize")]
        public OutputSize OutputSize
        {
            get { return GetParameter(); }
            set { SetParameter(value); }
        }

        [ApiParameter("datatype")]
        public DataType DataType
        {
            get { return GetParameter(); }
            set { SetParameter(value); }
        }
    }
}
