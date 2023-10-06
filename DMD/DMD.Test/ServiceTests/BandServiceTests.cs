using Microsoft.Extensions.Logging;
using DMD.Domain.Configuration;
using DMD.Domain.Models;
using DMD.Domain.Services;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;

namespace DMD.Test.ServiceTests
{
    public class BandServiceTests
    {
        private readonly IBandService _bandService;
        private readonly Mock<ILogger<BandService>> _logger;

        public BandServiceTests()
        {
            // cross test setup
            _logger = new Mock<ILogger<BandService>>();
            ILogger<BandService> logger = _logger.Object;

            IOptions<BandOptions> options = Options.Create(new BandOptions());

            _bandService = new BandService(options, logger);
        }

        [Fact]
        public async Task GetAllBands_Succeeds()
        {
            // setup

            // act
            List<Band> result = await _bandService.GetAllBandsAsync(CancellationToken.None);

            // assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task GetBandByName_Succeeds()
        {
            // setup
            string bandName = "metallica";

            // act
            Band result = await _bandService.GetBandByNameAsync(bandName, CancellationToken.None);

            // assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task GetBandByName_NonExistentName_Fails()
        {
            // setup
            string bandName = "thisbanddoesnotexist";

            // act
            Task result() => _bandService.GetBandByNameAsync(bandName, CancellationToken.None);

            // assert
            await Assert.ThrowsAsync<InvalidOperationException>(result);
        }
    }
}