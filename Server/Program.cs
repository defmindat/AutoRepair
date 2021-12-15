using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AutoRepair
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // Тестовая инициализация данных
            // using (var serviceScope = host.Services.CreateScope())
            // {
            //     var facade = serviceScope.ServiceProvider.GetRequiredService<DomainModelFacade>();
            //     var initializer = new SampleAppInitializer(facade);
            //     initializer.Init();
            // }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}