using Exus.AlphaVantage.Attributes;
using Exus.AlphaVantage.Queries.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exus.AlphaVantage.Queries
{
    public class TimeSeriesMonthlyQuery : ApiQuery<QueryResults.TimeSeriesMonthlyQueryResult>
    {
        public TimeSeriesMonthlyQuery() : base(ApiFunction.TIME_SERIES_MONTHLY)
        {
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
