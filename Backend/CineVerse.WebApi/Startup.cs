using CineVerse.Persistence.DbContexts;
using CineVerse.WebApi.Helpers;
using GN2.AppSign.Library.Entities;
using GN2.AppSign.Library.Helpers;
using GN2.Business.Core.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CineVerse.WebApi;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _hostingEnvironment;

    private SwaggerConfiguration _swaggerConfig = new();
    private string connectionString = string.Empty;
    private string assemblyName = string.Empty;

    public Startup(IWebHostEnvironment env, IConfiguration configuration)
    {
        _hostingEnvironment = env;
        _configuration = configuration;


        connectionString = _configuration.GetConnectionString("Default") ?? string.Empty;
        assemblyName = Assembly.GetExecutingAssembly().GetName()?.Name ?? string.Empty;

        _configuration.GetSection(nameof(SwaggerConfiguration)).Bind(_swaggerConfig);
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddHttpContextAccessor();
        services.AddOpenApi();
        services.RegisterSwagger(_swaggerConfig);
        services.RegisterDbContext(connectionString, assemblyName);
        services.RegisterIdentity();
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        services.RegisterAuthentication();
        services.CookieSetting();
    }

    public void Configure(WebApplication app, IWebHostEnvironment env)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseSwaggerVersion(_swaggerConfig);
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseCors();
        app.MapControllers();
        app.Services.DatabaseMigrate();
    }
}
