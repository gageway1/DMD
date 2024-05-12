using DMD.Data.Models;

namespace DMD.Domain.Services
{
    public interface IBandService
    {
        Task<IList<DbBand>> GetAllBandsAsync(CancellationToken cancellationToken);
        Task<DbBand> GetBandByNameAsync(string bandName, CancellationToken cancellationToken);
        Task CreateBandAsync(string name, string genre, CancellationToken cancellationToken);
        Task ModifyBandAsync(Guid id, string name, string genre, string modifiedBy, CancellationToken cancellationToken);
    }
}