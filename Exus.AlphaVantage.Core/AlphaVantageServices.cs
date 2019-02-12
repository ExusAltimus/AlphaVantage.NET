using Exus.AlphaVantage.Core.Deserializer;
using Exus.AlphaVantage.Core.Deserializer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Exus.AlphaVantage.Core
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
            services.AddTransient<IApiQueryResultDeserializer<Stream>, ApiQueryResultDeserializer>();
            services.AddTransient<IApiQueryResultContractResolver, ApiQueryResultContractResolver>();
            services.AddTransient<ApiQueryResultJsonConverter, ApiQueryResultJsonConverter>();
        }
    }
}
