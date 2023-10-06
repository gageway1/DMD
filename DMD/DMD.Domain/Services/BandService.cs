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
        private readonly ILogger<BandService> _logger;

        public BandService(IOptions<BandOptions> options, ILogger<BandService> logger)
        {
            _options = options;
            _logger = logger;
            _logger.LogInformation($"Options!:\n[{nameof(options.Value.ApiKey)}] | {options.Value.ApiKey}\n[{nameof(options.Value.TenantId)}] | {options.Value.TenantId}");
        }

        public async Task<Band> GetBandByNameAsync(string bandName, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(_bandDataStore.Bands.First(band => band.Name.ToLower().Equals(bandName.ToLower())));
            }
            catch
            {
                _logger.LogError($"Couldn't get band [{bandName}] from the datastore.");
                throw;
            }
        }

        public async Task<List<Band>> GetAllBandsAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(_bandDataStore.Bands.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
