# AlphaVantage.NET
Fully Typed Alpha Vantage Api (https://www.alphavantage.co/) .NET Core C# Wrapper

### Basic usage example: 
```csharp
private const string ALPHA_VANTAGE_API_KEY = "Api key here";
```
```csharp
public async Task GetIntradayTimeSeries()
{
    var querier = new ApiQuerier(ALPHA_VANTAGE_API_KEY);
    
    // Intraday time series for MSFT:
    var query = new Exus.AlphaVantage.Queries.TimeSeriesIntradayQuery
    {
        Symbol = symbol
    };

    var result = await _apiQuerier.Query(query);
    
    // result.TimeSeries is a dictionary with the date time as the key
    foreach (var point in result.TimeSeries)
    {
        Console.WriteLine($"{point.Key}: {point.Value.Open}");
    }
}
```

### Dependency injection usage example: 

```csharp
private const string ALPHA_VANTAGE_API_KEY = "Api key here";
```
```csharp
// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{
    services.AddAlphaVantage();

    services.Configure<ApiQuerierSettings>(o =>
    {
        o.ApiKey = ALPHA_VANTAGE_API_KEY;
    });
}
```

```csharp
using Exus.AlphaVantage;
using Exus.AlphaVantage.QueryResults;

public class StockQuerierService
{
    public readonly IApiQuerier _apiQuerier; //Injected

    public StockQuerierService(IApiQuerier apiQuerier)
    {
        _apiQuerier = apiQuerier;
    }

    public async Task<TimeSeriesIntradayQueryResult> GetIntradayTimeSeries(string symbol)
    {
        var query = new Exus.AlphaVantage.Queries.TimeSeriesIntradayQuery
        {
            Symbol = symbol
        };

        var result = await _apiQuerier.Query(query);

        return result;
    }
}
 ````

