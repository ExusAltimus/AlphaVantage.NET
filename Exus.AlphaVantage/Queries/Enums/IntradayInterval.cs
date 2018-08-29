using Exus.AlphaVantage.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Queries.Enums
{
    public enum IntradayInterval
    {
        Unknown,
        [ApiEnum("1min")]
        OneMinute,
        [ApiEnum("5min")]
        FiveMinutes,
        [ApiEnum("15min")]
        FifteenMinutes,
        [ApiEnum("30min")]
        ThirtyMinutes,
        [ApiEnum("60min")]
        SixtyMinutes,
        [ApiEnum("60min")]
        OneHour
    }

}
