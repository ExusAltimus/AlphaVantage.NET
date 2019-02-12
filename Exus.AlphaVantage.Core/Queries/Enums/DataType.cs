using Exus.AlphaVantage.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Core.Queries.Enums
{

    public enum DataType
    {
        Unknown,
        [ApiEnum("json")]
        Json,
        [ApiEnum("csv")]
        Csv
    }

}
