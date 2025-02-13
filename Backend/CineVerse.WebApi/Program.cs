using GN2.AppSign.Library.Helpers;

namespace CineVerse.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.RegisterApiServer();

        var configuration = new Startup(builder.Environment, builder.Configuration);
        configuration.ConfigureServices(builder.Services);
        var app = builder.Build();
        configuration.Configure(app, app.Environment);
        app.Run();
    }
}



