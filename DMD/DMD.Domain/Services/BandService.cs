using DMD.Domain.Configuration;
using DMD.Domain.DataStores;
using DMD.Domain.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DMD.Domain.Services
{
    public sealed partial class BandService : IBandService
    {
        private readonly BandDataStore _bandDataStore = new();
        private readonly IOptions<BandOptions> _options;
        private readonly Logger _logger;

        public BandService(IOptions<BandOptions> options, ILogger logger)
        {
            _options = options;
            Console.WriteLine($"Options!: {nameof(options.Value.ApiKey)}{options.Value.ApiKey}\n\n{nameof(options.Value.TenantId)}{options.Value.TenantId}");
            _logger = new Logger(logger);
        }

        public async Task<Band> GetBandByNameAsync(string bandName, CancellationToken cancellationToken)
        {
            try
            {
                _logger.GetThingError("This is a log message!");
                return await Task.FromResult(_bandDataStore.Bands.First(name => name.Equals(bandName)));
            }
            catch (Exception)
            {
                throw; // error handling later, partial class DI ILogger<T> method with overloads
            }
        }

        public async Task<List<Band>> GetAllBandsAsync(CancellationToken cancellationToken)
        {
            try
            {
                _logger.GetThingError("This is a log message!");
                return await Task.FromResult(_bandDataStore.Bands.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    internal sealed partial class Logger
    {
        private readonly ILogger _logger;

        public Logger(ILogger logger)
        {
            _logger = logger;
        }

        [LoggerMessage(1, LogLevel.Error, "Oh no! We couldn't get [{thing}]!")]
        internal partial void GetThingError(string thing);
    }

}
