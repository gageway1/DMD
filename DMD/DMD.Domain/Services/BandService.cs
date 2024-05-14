using DMD.Domain.Configuration;
using DMD.Data.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DMD.Data.Repositories;

namespace DMD.Domain.Services
{
    public sealed class BandService : IBandService
    {
        private readonly IOptions<BandOptions> _options;
        private readonly ILogger<BandService> _logger;
        private readonly IBandRepository _bandRepository;

        public BandService(IOptions<BandOptions> options, ILogger<BandService> logger, IBandRepository bandRepository)
        {
            _options = options;
            _logger = logger;
            _bandRepository = bandRepository;
            _logger.LogInformation($"Options!:\n[{nameof(_options.Value.ApiKey)}] | {_options.Value.ApiKey}\n[{nameof(_options.Value.TenantId)}] | {_options.Value.TenantId}");
        }

        public async Task<IEnumerable<DbBand>> GetAllBandsAsync(CancellationToken cancellationToken)
        {
            return await _bandRepository.GetAllBandsAsync();
        }

        public async Task CreateBandAsync(string name, string genre, CancellationToken cancellationToken)
        {
            await _bandRepository.InsertBandAsync(new DbBand() { Genre = genre, Name = name });
        }
    }
}
