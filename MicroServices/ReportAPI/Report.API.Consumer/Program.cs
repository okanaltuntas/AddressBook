using Report.API.QueeConsumers;
using Report.API.Services.Abstract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Report.API.Services.Concrete;
using Report.API.Services.Services;
using Report.API.GenericRepository;

namespace Report.API.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<GenerateReportConsumer>();
                services.AddTransient<ILocationReportService, LocationReportService>();
                services.AddTransient<IContactService, ContactService>();
                services.AddTransient<IContactInformationService, ContactInformationService>();
                services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            });
    }
}
