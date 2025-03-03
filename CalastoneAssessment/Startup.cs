using CalastoneAssessment.File;
using CalastoneAssessment.Processors;
using ConsoleApp1.TextFilters;
using ConsoleApp1.TextFilters.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CalastoneAssessment
{
    public static class Startup
    {
        public static IHostBuilder CreateDefaultBuilder(string[] args)
        {

            return Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                // register services here
                services.AddLogging(configure => configure.AddConsole());
                services.AddScoped<ITextFilter, Filter1>();
                services.AddScoped<ITextFilter, Filter2>();
                services.AddScoped<ITextFilter, Filter3>();
                services.AddScoped<IFileReader, FileReader>();
                services.AddScoped<IFileProcessor, FileProcessor>();

            });
        }
    }
}

