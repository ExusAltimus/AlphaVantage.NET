using Exus.AlphaVantage.Core.Attributes;
using Exus.AlphaVantage.Core.Queries.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exus.AlphaVantage.Core.Queries
{
    public class TimeSeriesMonthlyAdjustedQuery : ApiQuery<QueryResults.TimeSeriesMonthlyAdjustedQueryResult>
    {
        public TimeSeriesMonthlyAdjustedQuery() : base(ApiFunction.TIME_SERIES_MONTHLY_ADJUSTED)
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
