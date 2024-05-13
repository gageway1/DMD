using DMD.Data.Models;
using DMD.Web.Models;
using Nelibur.ObjectMapper;

public static class TinyMapperExtensions
{
    public static void ConfigureMappings()
    {
        // Bind individual and enumerable types
        TinyMapper.Bind<DbBand, Band>();
        TinyMapper.Bind<IEnumerable<DbBand>, IEnumerable<Band>>();
        TinyMapper.Bind<DbAlbum, Album>();
        TinyMapper.Bind<IEnumerable<DbAlbum>, IEnumerable<Album>>();
        TinyMapper.Bind<DbBandMember, BandMember>();
        TinyMapper.Bind<IEnumerable<DbBandMember>, IEnumerable<BandMember>>();
        TinyMapper.Bind<DbSong, Song>();
        TinyMapper.Bind<IEnumerable<DbSong>, IEnumerable<Song>>();

        // Bind complex objects within these mappings
        TinyMapper.Bind<DbBand, Band>(config =>
        {
            config.Bind(source => source.Albums, target => target.Albums);
            config.Bind(source => source.Members, target => target.BandMembers);
        });
        TinyMapper.Bind<DbAlbum, Album>(config =>
        {
            config.Bind(source => source.Songs, target => target.Songs);
        });
    }
}

public static class MappingConfigurationExtensions
{
    public static IServiceCollection AddMapping(this IServiceCollection services)
    {
        TinyMapperExtensions.ConfigureMappings();
        return services;
    }
}
