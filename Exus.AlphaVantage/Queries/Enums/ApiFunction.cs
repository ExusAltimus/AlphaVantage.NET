using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Queries.Enums
{
    public enum ApiFunction
    {
        Unknown,
        // Stock Time Series
        TIME_SERIES_INTRADAY,
        TIME_SERIES_DAILY,
        TIME_SERIES_DAILY_ADJUSTED,
        TIME_SERIES_WEEKLY,
        TIME_SERIES_WEEKLY_ADJUSTED,
        TIME_SERIES_MONTHLY,
        TIME_SERIES_MONTHLY_ADJUSTED,
        // Foreign Exchange
        CURRENCY_EXCHANGE_RATE,
        // Digital Currency
        DIGITAL_CURRENCY_INTRADAY,
        DIGITAL_CURRENCY_DAILY,
        DIGITAL_CURRENCY_WEEKLY,
        DIGITAL_CURRENCY_MONTHLY,
        // Technical Indicator
    }
}
