using Exus.AlphaVantage.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Queries.Enums
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
