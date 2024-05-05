using TaskScheduler.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);
        builder.ConfigureServices((hostContext, services) =>
        {
            services.AddDbContext<TaskSchedulerDbContext>(options =>
                options.UseSqlServer(hostContext.Configuration.GetConnectionString("TaskSchedulerDb")));
            services.AddHostedService<Worker>();
        });

        var host = builder.Build();
        host.Run();
    }
}