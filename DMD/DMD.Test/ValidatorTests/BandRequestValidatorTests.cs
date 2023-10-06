using DMD.Domain.Models;
using DMD.Domain.Queries;
using DMD.Domain.Services;
using DMD.Domain.Validators;
using FluentAssertions;
using MediatR;
using Moq;
using FluentValidation.TestHelper;


namespace DMD.Test.ValidatorTests
{
    public class BandRequestValidatorTests
    {
        private readonly GetBandByNameRequestValidator _validator;

        public BandRequestValidatorTests()
        {
            _validator = new GetBandByNameRequestValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("    ")]
        [InlineData("           ")]
        public async Task Validator_ThrowsValidationErrors_InvalidInput(string request)
        {
            TestValidationResult<GetBandByNameRequest> result = await _validator.TestValidateAsync(new GetBandByNameRequest(request));
            result.ShouldHaveValidationErrorFor(p => p.Name);
        }

        [Theory]
        [InlineData("a")]
        [InlineData(". aa")]
        [InlineData("ba")]
        [InlineData("pneumonoultramicroscopicsilicovolcanoconiosis")]
        public async Task Validator_ValidatesSuccessfully(string request)
        {
            TestValidationResult<GetBandByNameRequest> result = await _validator.TestValidateAsync(new GetBandByNameRequest(request));
            result.ShouldNotHaveValidationErrorFor(p => p.Name);
        }
    }
}
