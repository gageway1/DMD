using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DMD.Common
{
    public static class OptionsValidation
    {
        // adds options! but does not validate! shame!
        public static IServiceCollection AddOptions<TOptions>(
            this IServiceCollection services,
            IConfiguration configuration,
            string settingsName)
            where TOptions : class, new()
        {
            TOptions op = new();

            configuration.GetSection(settingsName).Bind(op);

            services.AddOptions<TOptions>()
                .Bind(configuration.GetSection(settingsName))
                .PostConfigure(option => ValidateIOptions(option, settingsName));

            services.Configure<TOptions>(_ => configuration.GetSection(settingsName));
            return services;
        }

        // Not validating!!! idk why!!! will fix later.
        private static void ValidateIOptions<TOptions>(TOptions options, string sectionName) where TOptions : class
        {
            List<ValidationResult> validationResults = new();
            StringBuilder sb = new();

            object option = options;
            ValidationContext context = new(option);

            if (!Validator.TryValidateObject(option, context, validationResults) || string.IsNullOrEmpty(sectionName))
            {
                if (validationResults.Count > 0)
                {
                    IEnumerable<string?> errors = validationResults.Select(r => r.ErrorMessage);

                    foreach (string? error in errors)
                    {
                        sb.AppendLine(error);
                    }

                    throw new ArgumentException($"Invalid configuration of section '{sectionName}':\n{sb}");
                }
                if (string.IsNullOrEmpty(sectionName))
                {
                    throw new Exception($"No valid section name provided. Check appsettings.json and see if your app settings are configured properly for the class option {typeof(TOptions)}");
                }
            }

            return;
        }
    }
}
