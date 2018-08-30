using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exus.AlphaVantage
{
    /// <summary>
    /// Queries the api endpoint and returns raw data
    /// </summary>
    public interface IApiWebClient
    {
        Task<TApiQueryResult> Query<TApiQueryResult>(IApiQuery<TApiQueryResult> query);
    }

}
