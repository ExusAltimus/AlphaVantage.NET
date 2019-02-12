# AlphaVantage.NET
Fully Typed Alpha Vantage Api (https://www.alphavantage.co/) .NET Core C# Wrapper

Nuget
https://www.nuget.org/packages/Exus.AlphaVantage.Core/

## Basic usage example: 

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

## Dependency injection usage example: 

Startup.cs
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

StockQuerierService.cs
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
```
 
## Use your own implementations w/ dependency injection: 
This library provides several useful interfaces that integrate with dependency injection services that enable you to provide your own implementations.

### IApiQuerier
Processes a query object and returns a query result
### IApiWebClient
Web client used by the default ApiQuerier that retrieves a response and deserializes into an object
### IApiQueryResultDeserializer<TDataType>
Deserializer used by the default Web client to deserialize a response string (json)
Note: The datatype exists incase anything other than a string needs to be deserialized, such as a memory stream or file
### IApiQueryResultContractResolver
Json.NET Contract resolver used by the default deserializer
### ApiQueryResultJsonConverter
Json.NET converter used by the default deserializer
    
## Default services

AlphaVantageServices.cs
```csharp
public static void AddAlphaVantage(this IServiceCollection services)
{
    services.AddTransient<IApiQuerier, ApiQuerier>();
    services.AddTransient<IApiWebClient, ApiWebClient>();
    services.AddTransient<IApiQueryResultDeserializer<string>, ApiQueryResultDeserializer>();
    services.AddTransient<IApiQueryResultContractResolver, ApiQueryResultContractResolver>();
    services.AddTransient<ApiQueryResultJsonConverter, ApiQueryResultJsonConverter>();
}
```

## Example custom implementation
MyCustomApiWebClient.cs
```csharp
public class MyCustomApiWebClient : IApiWebClient
{ 
    public const string QUERY_URL = "https://www.alphavantage.co/query";

    private readonly IApiQueryResultDeserializer<string> _deserializer;

    public MyCustomApiWebClient()
    {
        _deserializer = new ApiQueryResultDeserializer();
    }

    public ApiWebClient(IApiQueryResultDeserializer<string> deserializer)
    {
        _deserializer = deserializer;
    }

    public async Task<TApiQueryResult> Query<TApiQueryResult>(IApiQuery<TApiQueryResult> query)
    {
        using (var webClient = new System.Net.WebClient())
        {
            webClient.QueryString = query.Parameters.Aggregate(new NameValueCollection(),
                        (seed, current) => {
                            seed.Add(current.Key, current.Value);
                            return seed;
                        });
            var json = await webClient.DownloadStringTaskAsync(QUERY_URL);
            return _deserializer.Deserialize<TApiQueryResult>(json);
        }    
    }
}
```

Startup.cs
```csharp
// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
{
    services.AddAlphaVantage();

    services.AddTransient<IApiWebClient, MyCustomApiWebClient>();
}
```
