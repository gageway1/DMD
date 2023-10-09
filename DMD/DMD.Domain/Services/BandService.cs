using DMD.Domain.Configuration;
using DMD.Data.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DMD.Data;
using Microsoft.EntityFrameworkCore;
using DMD.Data.Exceptions;

namespace DMD.Domain.Services
{
    public sealed class BandService : IBandService
    {
        private readonly IOptions<BandOptions> _options;
        private readonly ILogger<BandService> _logger;
        private readonly DMDContext _context;

        public BandService(IOptions<BandOptions> options, ILogger<BandService> logger, DMDContext context)
        {
            _options = options;
            _logger = logger;
            _context = context;
            _logger.LogInformation($"Options!:\n[{nameof(_options.Value.ApiKey)}] | {_options.Value.ApiKey}\n[{nameof(_options.Value.TenantId)}] | {_options.Value.TenantId}");
        }

        public async Task<DbBand> GetBandByNameAsync(string bandName, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Bands.FirstAsync(c => c.Name.ToLower() == bandName.ToLower(), cancellationToken);
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundInDbOkException($"No band found with name [{bandName}]");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<List<DbBand>> GetAllBandsAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Bands.ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        public async Task<DbBand> CreateBandAsync(string name, string genre, CancellationToken cancellationToken)
        {
            DbBand band = new()
            {
                Name = name,
                Genre = genre
            };

            try
            {
                await _context.Bands.AddAsync(band, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

            return _context.Bands.First(c => c.Id == band.Id);
        }

        public async Task<DbBand> ModifyBandAsync(Guid id, string name, string genre, string modifiedBy, CancellationToken cancellationToken)
        {
            DbBand band;
            try
            {
                band = _context.Bands.First(c => c.Id == id);
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogError(ex.ToString());
                throw new BandNotFoundException($"No band found for ID [{id}]");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

            band.ModifiedBy = modifiedBy;
            band.Genre = genre;
            band.Name = name;

            try
            {
                _context.Bands.Update(band);
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

            return band;
        }
    }
}
