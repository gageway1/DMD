using DMD.Data.Models;
using DMD.Data.Repositories.Base;
using DMD.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace DMD.Data.Repositories
{
    public class BandRepository : Repository<DbBand>, IBandRepository, IDisposable
    {
        private readonly DMDContext _context;
        private readonly ILogger<BandRepository> _logger;

        public BandRepository(DMDContext context, ILogger<BandRepository> logger) : base(context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task DeleteBandAsync(Guid id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogError($"Exception caught in [DeleteBandAsync]: Exception: \n{ex.InnerException}\nStack Trace:\n{ex.StackTrace}");
            }
        }

        public async Task<IEnumerable<DbBand>> GetAllBandsAsync()
        {
            try
            {
                var query = await GetAllAsync(p => p
                .Include(p => p.Members)
                .Include(p => p.Albums)
                    .ThenInclude(x => x.Songs)
                .OrderByDescending(p => p.CreatedOn));
                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception caught in [GetAllBandsAsync]: Exception: \n{ex.InnerException}\nStack Trace:\n{ex.StackTrace}");
                return new List<DbBand>();
            }
        }

        public async Task InsertBandAsync(DbBand band)
        {
            try
            {
                await _context.Bands.AddAsync(band);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception caught in [InsertBandAsync]: Exception: \n{ex.InnerException}\nStack Trace:\n{ex.StackTrace}");
            }
        }

        public async void UpdateBand(DbBand band)
        {
            try
            {
                var b = await _context.Bands.Where(p => p.Id == band.Id).FirstOrDefaultAsync();
                b = band;
                _context.Entry(b).State = EntityState.Modified;
                _context.Bands.Update(b);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception caught in [UpdateBand]: Exception: \n{ex.InnerException}\nStack Trace:\n{ex.StackTrace}");
            }
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
