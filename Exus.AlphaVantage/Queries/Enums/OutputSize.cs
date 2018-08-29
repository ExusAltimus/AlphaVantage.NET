using Exus.AlphaVantage.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Queries.Enums
{
    public enum OutputSize
    {
        Unknown,
        [ApiEnum("compact")]
        Compact,
        [ApiEnum("full")]
        Full
    }
}
