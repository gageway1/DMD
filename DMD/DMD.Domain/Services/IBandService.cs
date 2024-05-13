using DMD.Data.Models;

namespace DMD.Domain.Services
{
    public interface IBandService
    {
        Task<IEnumerable<DbBand>> GetAllBandsAsync(CancellationToken cancellationToken);
        Task CreateBandAsync(string name, string genre, CancellationToken cancellationToken);
    }
}