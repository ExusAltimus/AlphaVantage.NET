using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage.Core
{
    public interface IApiQueryResultDeserializer<TDataType>
    {
        TApiQueryResult Deserialize<TApiQueryResult>(TDataType data);
    }
}
