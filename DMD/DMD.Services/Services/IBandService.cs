using DMD.Domain.Models;

namespace DMD.Domain.Services
{
    public interface IBandService
    {
        Task<List<Band>> GetAllBandsAsync(CancellationToken cancellationToken);
        Task<Band> GetBandByNameAsync(string bandName, CancellationToken cancellationToken);
    }
}