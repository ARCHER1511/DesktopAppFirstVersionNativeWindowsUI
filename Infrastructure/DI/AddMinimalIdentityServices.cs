using ERPAppDomain.Entities;
using ERPAppInfrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace ERPAppInfrastructure.DI
{
    public static class AddMinimalIdentityServicesDI
    {
        public static IServiceCollection AddMinimalIdentityServices(this IServiceCollection services)
        {
            // Identity options
            services.AddSingleton<IOptions<IdentityOptions>>(new OptionsWrapper<IdentityOptions>(new IdentityOptions
            {
                Password = new PasswordOptions
                {
                    RequireDigit = true,
                    RequiredLength = 6,
                    RequireNonAlphanumeric = false,
                    RequireUppercase = false,
                    RequireLowercase = false
                }
            }));

            // Required Identity services
            services.AddSingleton<ILookupNormalizer, UpperInvariantLookupNormalizer>();
            services.AddSingleton<IdentityErrorDescriber>();
            services.AddScoped<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();
            services.AddScoped<IUserValidator<ApplicationUser>, UserValidator<ApplicationUser>>();
            services.AddScoped<IPasswordValidator<ApplicationUser>, PasswordValidator<ApplicationUser>>();
            services.AddScoped<IUserStore<ApplicationUser>, UserStore<ApplicationUser, ApplicationRole, ERPAppContext, Guid>>();
            services.AddScoped<IRoleStore<ApplicationRole>, RoleStore<ApplicationRole, ERPAppContext, Guid>>();

            // Add logging for UserManager/RoleManager
            services.AddLogging();

            // Register managers
            services.AddScoped<UserManager<ApplicationUser>>();
            services.AddScoped<RoleManager<ApplicationRole>>();

            return services;
        }
    }
}
