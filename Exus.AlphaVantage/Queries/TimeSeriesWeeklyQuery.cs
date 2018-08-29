using Exus.AlphaVantage.Attributes;
using Exus.AlphaVantage.Queries.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exus.AlphaVantage.Queries
{
    public class TimeSeriesWeeklyQuery : ApiQuery<QueryResults.TimeSeriesWeeklyQueryResult>
    {
        public TimeSeriesWeeklyQuery()
        {
            this.Function = ApiFunction.TIME_SERIES_WEEKLY;
        }

        [ApiParameter("symbol")]
        public string Symbol {
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
