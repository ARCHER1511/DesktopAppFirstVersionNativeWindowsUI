using ERPApp.DI;
using ERPAppApplication.DI;
using ERPAppInfrastructure.DI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ERPApp.Configuration
{
    public static class AppInitializer
    {
        public static IServiceProvider Build()
        {
            var services = new ServiceCollection();

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            //register IConfiguration for DI
            services.AddSingleton(configuration);

            // Add Infrastructure Layer
            services.AddInfrastructureServices(configuration);

            // Add Application Layer
            services.AddApplicationServices();

            // Add WPF Layer (Views + ViewModels)
            services.AddWPFServices();

            return services.BuildServiceProvider();
        }
    }
}
