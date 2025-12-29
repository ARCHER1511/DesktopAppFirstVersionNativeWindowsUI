using ERPAppApplication.Interfaces;
using ERPAppApplication.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ERPAppApplication.DI
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
