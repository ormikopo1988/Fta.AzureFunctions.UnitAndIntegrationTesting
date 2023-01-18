using Fta.DemoFunc.Api.Interfaces;
using Fta.DemoFunc.Api.Logging;
using Fta.DemoFunc.Api.Repositories;
using Fta.DemoFunc.Api.Services;
using Fta.DemoFunc.Api.Settings;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Fta.DemoFunc.Api.Startup))]
namespace Fta.DemoFunc.Api
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var config = new ConfigurationBuilder()
                 .SetBasePath(Environment.CurrentDirectory)
                 .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                 .AddEnvironmentVariables()
                 .Build();

            var cosmosDbSettings = new CosmosDbSettings();
            config.Bind(CosmosDbSettings.CosmosDbSectionKey, cosmosDbSettings);
            builder.Services.AddSingleton(cosmosDbSettings);
            builder.Services.AddTransient(typeof(ILoggerAdapter<>), typeof(LoggerAdapter<>));
            builder.Services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            builder.Services.AddScoped<INoteService, NoteService>();
            builder.Services.AddScoped<INoteRepository, NoteRepository>();
        }
    }
}
