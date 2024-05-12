using DMD.Data.Models;
using DMD.Data.Repositories.Base;

namespace DMD.Data.Repositories
{
    public interface IBandRepository : IRepository<DbBand>, IDisposable
    {
        Task<IList<DbBand>> GetAllBandsAsync();
        Task<DbBand> GetBandByNameAsync(string bandName);
        Task<DbBand> GetBandByIdAsync(Guid bandId);
        Task InsertBandAsync(DbBand band);
        void UpdateBand(DbBand band);
        Task DeleteBandAsync(Guid id);
    }
}
