using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Fta.DemoFunc.Api.Tests.Integration
{
    public class TestStartup : Startup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            base.Configure(builder);
            builder.Services.AddTransient<NotesFunction>();
        }
    }
}
