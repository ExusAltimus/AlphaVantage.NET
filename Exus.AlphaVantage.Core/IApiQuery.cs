using Exus.AlphaVantage.Core.Queries.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Core
{
    public interface IApiQuery<TApiResult>
    {
        Dictionary<string, string> Parameters { get; set; }
        string ApiKey { get; set; }
        ApiFunction Function { get; set; }
    }
}
