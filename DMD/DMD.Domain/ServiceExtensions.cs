using DMD.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMD.Domain
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddBandService(this IServiceCollection services)
        {
            services.AddSingleton<IBandService, BandService>();
            return services;
        }
    }
}
