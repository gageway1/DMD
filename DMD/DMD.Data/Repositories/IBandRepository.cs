using DMD.Data.Models;
using DMD.Data.Repositories.Base;

namespace DMD.Data.Repositories
{
    public interface IBandRepository : IRepository<DbBand>, IDisposable
    {
        Task<IEnumerable<DbBand>> GetAllBandsAsync();
        Task InsertBandAsync(DbBand band);
        void UpdateBand(DbBand band);
        Task DeleteBandAsync(Guid id);
    }
}
