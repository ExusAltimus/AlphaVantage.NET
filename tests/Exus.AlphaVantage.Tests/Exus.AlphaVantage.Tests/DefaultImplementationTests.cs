using Exus.AlphaVantage.Queries.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Exus.AlphaVantage.Tests
{
    public class DefaultImplementationTests
    {
        private const string ApiKey = "";

        [Fact]
        public async Task BasicQueryTest()
        {
            var apiQuerier = new ApiQuerier(ApiKey);
            var query = new Exus.AlphaVantage.Queries.TimeSeriesDailyQuery
            {
                Symbol = "MSFT"
            };

            var result = await apiQuerier.Query(query);

            Assert.NotNull(result);
            Assert.True(result.TimeSeries.Count > 0);
        }

        [Fact]
        public async Task BadQueryTest()
        {
            var apiQuerier = new ApiQuerier(ApiKey);
            var symbol = "bad_symbol";
            var interval = "15min";
            var query = new ApiQuery<object>(ApiFunction.TIME_SERIES_INTRADAY, new Dictionary<string, string>()
            {
                { nameof(symbol), symbol },
                { nameof(interval), interval }
            });

            await Assert.ThrowsAsync<ApiQueryErrorException>(async () =>
            {
                var result = await apiQuerier.Query(query);
            });
        }

        [Fact]
        public async Task DyanmicResultTest()
        {
            var apiQuerier = new ApiQuerier(ApiKey);
            var query = new Exus.AlphaVantage.ApiQuery<dynamic>(new Dictionary<string, string>()
            {
                { "function", "CURRENCY_EXCHANGE_RATE" },
                { "from_currency", "USD" },
                { "to_currency", "BTC" }
            });

            var result = await apiQuerier.Query(query);
            Assert.NotNull(result);
        }
    }
}
