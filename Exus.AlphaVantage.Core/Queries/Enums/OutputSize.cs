using Exus.AlphaVantage.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Core.Queries.Enums
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
