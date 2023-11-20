using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XmcSearchPublishing.SearchIndexUpdate.Edge;

namespace FunctionApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(s =>
                {
                    s.AddApplicationInsightsTelemetryWorkerService();
                    s.AddSingleton<IEdgeDataRetriever, EdgeDataRetriever>();
                })
                .Build();

            await host.RunAsync();
        }
    }
}
