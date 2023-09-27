using DMD.Domain.Configuration;
using DMD.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DMD.Common;
using Microsoft.Extensions.Logging;

namespace DMD.Domain
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBandService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<BandOptions>(configuration, BandOptions.SettingsName);
            services.AddSingleton<IBandService, BandService>();

            return services;
        }
    }
}
