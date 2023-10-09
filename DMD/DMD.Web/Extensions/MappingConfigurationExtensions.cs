using DMD.Data.Models;
using DMD.Web.Models;
using Nelibur.ObjectMapper;
using Nelibur.ObjectMapper.Bindings;

namespace DMD.Web.Extensions
{
    public static class MappingConfigurationExtensions
    {
        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            TinyMapperExtensions.BindForEnumerables<DbBand, Band>();
            TinyMapperExtensions.BindForEnumerables<DbAlbum, Album>();
            TinyMapperExtensions.BindForEnumerables<DbBandMember, BandMember>();
            TinyMapperExtensions.BindForEnumerables<DbSong, Song>();

            return services;
        }
    }

    public static class TinyMapperExtensions
    {
        public static void BindForEnumerables<TFrom, TTo>(Action<IBindingConfig<TFrom, TTo>>? config = null)
        {
            if (config is not null)
            {
                TinyMapper.Bind(config);
            }
            else
            {
                TinyMapper.Bind<TFrom, TTo>();
            }
            TinyMapper.Bind<IEnumerable<TFrom>, IEnumerable<TTo>>();
            TinyMapper.Bind<IList<TFrom>, IList<TTo>>();
            TinyMapper.Bind<List<TFrom>, List<TTo>>();
        }
    }
}
