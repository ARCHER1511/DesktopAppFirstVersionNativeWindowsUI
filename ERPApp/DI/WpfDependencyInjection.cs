using ERPApp.ViewModels;
using ERPApp.Views.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace ERPApp.DI
{
    public static class WpfDependencyInjection
    {
        public static IServiceCollection AddWPFServices(this IServiceCollection services)
        {
            //viewmodels
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<HomeViewModel>();
            //views
            services.AddTransient<MainWindow>();
            services.AddTransient<LoginPage>();
            services.AddTransient<RegisterPage>();
            services.AddTransient<HomePage>();


            return services;
        }
    }
}
