using DMD.Data;
using DMD.Data.Repositories;
using DMD.Domain;
using DMD.Domain.Middleware;
using DMD.Web.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // logger
        builder.UseSerilog((builder, configuration) => configuration
            .WriteTo.Console(Serilog.Events.LogEventLevel.Debug, theme: AnsiConsoleTheme.Code)
            .WriteTo.File("logging/log.txt", Serilog.Events.LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(builder.Configuration));

        string? connectionString = builder.Configuration.GetConnectionString("DMDDb");
        builder.Services.AddDbContext<DMDContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddScoped<IUnitOfWork, DMDContext>();

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Add mediatr
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(DomainMarker).Assembly));

        // add request validation
        builder.Services.AddValidatorsFromAssembly(typeof(DomainMarker).Assembly);
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        builder.Services.AddTransient<ExceptionHandlingMiddleware>();

        // domain services
        builder.Services.AddDomainServices(builder.Configuration);

        // mapping configuration
        builder.Services.AddMapping();

        WebApplication app = builder.Build();

        app.Logger.LogInformation("Listening on:");
        foreach (string url in Environment.GetEnvironmentVariable("ASPNETCORE_URLS")!.Split(";"))
        {
            app.Logger.LogInformation(url);
        }


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.Logger.LogInformation("App is in development mode");

            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        app.Logger.LogInformation("Running application");

        app.Run();

    }
}
