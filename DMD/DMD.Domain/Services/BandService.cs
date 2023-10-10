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
        private readonly IUnitOfWork _unitOfWork;

        public BandService(IOptions<BandOptions> options, ILogger<BandService> logger, IBandRepository bandRepository, IUnitOfWork unitOfWork)
        {
            _options = options;
            _logger = logger;
            _bandRepository = bandRepository;
            _unitOfWork = unitOfWork;
            _logger.LogInformation($"Options!:\n[{nameof(_options.Value.ApiKey)}] | {_options.Value.ApiKey}\n[{nameof(_options.Value.TenantId)}] | {_options.Value.TenantId}");
        }

        public async Task<DbBand> GetBandByNameAsync(string bandName, CancellationToken cancellationToken)
        {
            return await _bandRepository.GetBandByNameAsync(bandName);
        }

        public async Task<List<DbBand>> GetAllBandsAsync(CancellationToken cancellationToken)
        {
            List<DbBand> result = new List<DbBand>();
            await foreach (DbBand band in _bandRepository.GetAllBandsAsync())
            {
                result.Add(band);
            }
            return result;
        }

        public async Task CreateBandAsync(string name, string genre, CancellationToken cancellationToken)
        {
            await _bandRepository.InsertBandAsync(new DbBand() { Genre = genre, Name = name });
            await _unitOfWork.CommitAsync();
        }

        public async Task ModifyBandAsync(Guid id, string name, string genre, string modifiedBy, CancellationToken cancellationToken)
        {
            DbBand band = await _bandRepository.GetBandByIdAsync(id);
            _bandRepository.UpdateBand(band);
            await _unitOfWork.CommitAsync();
        }
    }
}
