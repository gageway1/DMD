using DMD.Data.Models;

namespace DMD.Data.Repositories
{
    public interface IBandRepository : IDisposable
    {
        IAsyncEnumerable<DbBand> GetAllBandsAsync();
        Task<DbBand> GetBandByNameAsync(string bandName);
        Task<DbBand> GetBandByIdAsync(Guid bandId);
        Task InsertBandAsync(DbBand band);
        void UpdateBand(DbBand band);
        Task DeleteBandAsync(Guid id);
    }
}
