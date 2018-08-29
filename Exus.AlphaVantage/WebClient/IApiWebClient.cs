using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exus.AlphaVantage
{
    public interface IApiWebClient
    {
        Task<TApiQueryResult> Query<TApiQueryResult>(IApiQuery<TApiQueryResult> query);
        //Task<TApiQueryResult> Query(ApiQuery query);
    }
}
