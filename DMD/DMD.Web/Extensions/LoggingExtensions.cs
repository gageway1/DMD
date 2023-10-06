using Serilog;

namespace DMD.Web.Extensions
{
    public static class LoggingExtensions
    {
        public static WebApplicationBuilder UseSerilog(
            this WebApplicationBuilder builder,
            Action<WebApplicationBuilder, LoggerConfiguration> configureLogger)
        {
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration();
            configureLogger(builder, loggerConfiguration);
            Serilog.Core.Logger logger = loggerConfiguration.CreateLogger();
            builder.Services.AddLogging(lb => lb.ClearProviders());
            builder.Logging.AddSerilog(logger);
            builder.Services.AddSingleton<Serilog.ILogger>(logger);

            return builder;
        }

    }
}
