using CineVerse.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace CineVerse.WebApi.Helpers;

public static class StartupHelper
{
    public static IServiceProvider DatabaseMigrate(this IServiceProvider services)
    {
        using (var serviceScope = services.CreateScope())
        {
            var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (dbContext != null)
            {
                dbContext.Database.Migrate();
            }
        }

        return services;
    }

    public static IServiceCollection RegisterDbContext(this IServiceCollection services, string connectionString, string assemblyName)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly(assemblyName)
            )
        );
        return services;
    }

    public static IServiceCollection CookieSetting(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(options =>
        {
            // Cookie settings
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
            options.AccessDeniedPath = "/Account/AccessDenied";
            options.SlidingExpiration = true;
        });

        return services;
    }
}
