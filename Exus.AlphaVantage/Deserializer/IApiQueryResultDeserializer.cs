using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage
{
    public interface IApiQueryResultDeserializer<TDataType>
    {
        TApiQueryResult Deserialize<TApiQueryResult>(TDataType data);
    }
}
