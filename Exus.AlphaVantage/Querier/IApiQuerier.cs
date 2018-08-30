using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exus.AlphaVantage
{
    /// <summary>
    /// Processes a query object and returns a query result
    /// </summary>
    public interface IApiQuerier
    {
        Task<TApiQueryResult> Query<TApiQueryResult>(IApiQuery<TApiQueryResult> query);
    }
}
