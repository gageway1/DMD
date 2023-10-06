using DMD.Web.Models;
using Nelibur.ObjectMapper;
using Nelibur.ObjectMapper.Bindings;

namespace DMD.Web.Extensions
{
    public static class MappingConfigurationExtensions
    {
        public static IServiceCollection AddMapping(this IServiceCollection s)
        {
            TinyMapperExtensions.BindForEnumerables<Domain.Models.Band, Band>();
            TinyMapperExtensions.BindForEnumerables<Domain.Models.Album, Album>();
            TinyMapperExtensions.BindForEnumerables<Domain.Models.BandMember, BandMember>();
            TinyMapperExtensions.BindForEnumerables<Domain.Models.Song, Song>();

            return s;
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
