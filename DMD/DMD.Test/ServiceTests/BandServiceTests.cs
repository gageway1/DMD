using Microsoft.Extensions.Logging;
using DMD.Domain.Configuration;
using DMD.Data;
using DMD.Domain.Services;
using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using DMD.Data.Models;
using DMD.Data.Repositories;

namespace DMD.Test.ServiceTests
{
    public class BandServiceTests
    {
        private readonly IBandService _bandService;
        private readonly Mock<ILogger<BandService>> _logger;
        private readonly Mock<DMDContext> _context;
        private readonly Mock<IBandRepository> _repository;

        public BandServiceTests()
        {
            // cross test setup
            _logger = new Mock<ILogger<BandService>>();
            ILogger<BandService> logger = _logger.Object;
            _repository = new Mock<IBandRepository>(MockBehavior.Strict);

            _context = new Mock<DMDContext>();

            IOptions<BandOptions> options = Options.Create(new BandOptions());

            _bandService = new BandService(options, logger, _repository.Object);
        }

        [Fact]
        public async Task GetAllBands_Succeeds()
        {
            // setup

            // act
            IEnumerable<DbBand> result = await _bandService.GetAllBandsAsync(CancellationToken.None);

            // assert
            result.Should().NotBeNull();
            result.ToList().Count.Should().BeGreaterThan(0);
        }
    }
}