﻿using DMD.Domain.Configuration;
using DMD.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DMD.Common;

namespace DMD.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {
            // add your services and options for those services here!!!
            services.AddOptions<BandOptions>(configuration, BandOptions.SettingsName);
            services.AddScoped<IBandService, BandService>();

            return services;
        }
    }
}
