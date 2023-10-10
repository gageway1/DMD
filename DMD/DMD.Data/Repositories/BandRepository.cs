using DMD.Data.Models;
using DMD.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DMD.Data.Repositories
{
    public class BandRepository : IBandRepository, IDisposable
    {
        private readonly DMDContext _context;
        private readonly ILogger<BandRepository> _logger;

        public BandRepository(DMDContext context, ILogger<BandRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task DeleteBandAsync(Guid id)
        {
            DbBand? band = await _context.Bands.FindAsync(id);
            if (band is not null)
            {
                _context.Bands.Remove(band);
            }
            else
            {
                throw new NotFoundInDbException($"No band found with ID [{id}]");
            }
        }

        public async IAsyncEnumerable<DbBand> GetAllBandsAsync()
        {
            await foreach (var band in _context.Bands.AsAsyncEnumerable())
            {
                yield return band;
            }
        }

        public async Task<DbBand> GetBandByIdAsync(Guid id)
        {
            DbBand? band = await _context.Bands.FindAsync(id);
            if (band is not null)
            {
                return band;
            }
            else
            {
                throw new NotFoundInDbException($"No band found with ID [{id}]");
            }
        }

        public async Task<DbBand> GetBandByNameAsync(string bandName)
        {
            DbBand? band = await _context.Bands.FirstAsync(b => b.Name == bandName);
            if (band is not null)
            {
                return band;
            }
            else
            {
                throw new NotFoundInDbException($"No band found with ID [{bandName}]");
            }
        }

        public async Task InsertBandAsync(DbBand band)
        {
            await _context.Bands.AddAsync(band);
        }

        public void UpdateBand(DbBand band)
        {
            _context.Entry(band).State = EntityState.Modified;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
