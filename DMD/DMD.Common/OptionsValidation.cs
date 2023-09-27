using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DMD.Common
{
    public static class OptionsValidation
    {
        public static IServiceCollection AddOptions<TOptions>(this IServiceCollection services, IConfiguration configuration, string settingsName)
            where TOptions : class, new()
        {
            TOptions op = new();

            configuration.GetSection(settingsName).Bind(op);

            services.AddOptions<TOptions>()
                .Bind(configuration.GetSection(settingsName))
                // TODO: my options validator is not doing the whole validation thing. look into this. it's seemingly binding nonexistent appsettings sections. why?
                .ValidateByDataAnnotation(settingsName);

            services.Configure<TOptions>(o => configuration.GetSection(settingsName));

            return services;
        }

        public static OptionsBuilder<TOptions> ValidateByDataAnnotation<TOptions>(this OptionsBuilder<TOptions> builder, string sectionName) where TOptions : class
        {
            return builder.PostConfigure(option => ValidateIOptions(option, sectionName));
        }

        private static void ValidateIOptions<TOptions>(TOptions options, string sectionName) where TOptions : class
        {
            List<ValidationResult> validationResults = new();
            StringBuilder sb = new();

            object option = options;
            ValidationContext context = new(option);

            if (Validator.TryValidateObject(option, context, validationResults))
            {
                return;
            }

            IEnumerable<string?> errors = validationResults.Select(r => r.ErrorMessage);

            foreach (string? error in errors)
            {
                sb.AppendLine(error);
            }

            throw new ArgumentException($"Invalid configuration of section '{sectionName}':\n{sb}");
        }
    }
}
