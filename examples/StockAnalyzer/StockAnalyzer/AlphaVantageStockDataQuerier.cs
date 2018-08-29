using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exus.AlphaVantage;
using Exus.AlphaVantage.QueryResults;
using StockAnalyzer.Models;

namespace StockAnalyzer
{

    public class AlphaVantageStockDataQuerier
    {
        public readonly IApiQuerier _apiQuerier;

        public AlphaVantageStockDataQuerier(IApiQuerier apiQuerier)
        {
            _apiQuerier = apiQuerier;
        }

        public async Task<TimeSeriesIntradayQueryResult> GetCurrentStockPrice(string symbol)
        {
            //var query = new Exus.AlphaVantage.Queries.TimeSeriesIntradayQuery
            //{
            //    Symbol = symbol
            //};

            var query = new Exus.AlphaVantage.ApiQuery<dynamic>(new Dictionary<string, string>()
            {
                { "function", "CURRENCY_EXCHANGE_RATE" },
                { "from_currency", "USD" },
                { "to_currency", "BTC" }
            });

            var result = await _apiQuerier.Query(query);

            return result;
        }
    }
}
