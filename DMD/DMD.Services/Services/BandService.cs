using DMD.Domain.DataStores;
using DMD.Domain.Models;

namespace DMD.Domain.Services
{
    public class BandService : IBandService
    {
        private readonly BandDataStore _bandDataStore = new();

        public BandService()
        {
            Console.WriteLine(_bandDataStore.Bands);
        }

        public async Task<Band> GetBandByNameAsync(string bandName, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(_bandDataStore.Bands.First(name => name.Equals(bandName)));

            }
            catch (Exception)
            {
                throw; // error handling later, partial class DI ILogger<T> method with overloads
            }
        }

        public async Task<List<Band>> GetAllBandsAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(_bandDataStore.Bands.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
