using DMD.Data.Models;

namespace DMD.Domain.Services
{
    public interface IBandService
    {
        Task<List<DbBand>> GetAllBandsAsync(CancellationToken cancellationToken);
        Task<DbBand> GetBandByNameAsync(string bandName, CancellationToken cancellationToken);
        Task<DbBand> CreateBandAsync(string name, string genre, CancellationToken cancellationToken);
        Task<DbBand> ModifyBandAsync(Guid id, string name, string genre, string modifiedBy, CancellationToken cancellationToken);
    }
}