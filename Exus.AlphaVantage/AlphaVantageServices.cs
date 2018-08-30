using Exus.AlphaVantage.Deserializer;
using Exus.AlphaVantage.Deserializer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exus.AlphaVantage
{
    public static class AlphaVantageServices
    {
        /// <summary>
        /// Default services
        /// </summary>
        /// <param name="services"></param>
        public static void AddAlphaVantage(this IServiceCollection services)
        {
            services.AddTransient<IApiQuerier, ApiQuerier>();
            services.AddTransient<IApiWebClient, ApiWebClient>();
            services.AddTransient<IApiQueryResultDeserializer<string>, ApiQueryResultDeserializer>();
            services.AddTransient<IApiQueryResultContractResolver, ApiQueryResultContractResolver>();
            services.AddTransient<ApiQueryResultJsonConverter, ApiQueryResultJsonConverter>();
        }
    }
}
