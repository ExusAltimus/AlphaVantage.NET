using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage
{

    public interface IApiQueryResultDeserializer
    {
        TApiQueryResult Deserialize<TApiQueryResult>(string json);
    }


}
