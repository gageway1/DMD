using DMD.Domain.Queries;
using DMD.Domain.Validators;
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

        [Fact]
        public async Task Validator_Throws_TooLongOfRequestParam()
        {
            string longstr = new('.', 101);
            TestValidationResult<GetBandByNameRequest> result = await _validator.TestValidateAsync(new GetBandByNameRequest(longstr));
            result.ShouldHaveValidationErrorFor(p => p.Name);
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
