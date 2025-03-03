using CalastoneAssessment;
using CalastoneAssessment.Processors;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Please provide the file path as a parameter.");
            return;
        }

        string filePath = args[0];

        var host = Startup.CreateDefaultBuilder(args).Build();

        var fileProcessor = host.Services.GetRequiredService<IFileProcessor>();
        fileProcessor.ProcessFile(filePath);
    }
}