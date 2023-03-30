using FluentAssertions;
using Xunit;
using static CreatePaymentCommand;

public class CreatePaymentCommandValidatorTests : IClassFixture<CommonTestFixture>
{
	CreatePaymentCommand command = new CreatePaymentCommand(null, null);
	CreatePaymentCommandValidator validator = new CreatePaymentCommandValidator();
	
	[Theory]
	[InlineData(-1, 0)]
	[InlineData(0, 20)]
	public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int CustomerId, int ProductId)
	{
		command.Model = new CreatePaymentViewModel()
		{
			CustomerId = 0,
			ProductId = 0,
		};
		
		var result = validator.Validate(command);
		result.Errors.Count.Should().BeGreaterThan(0);
	}
	
	[Fact]
	public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
	{
		command.Model = new CreatePaymentViewModel()
		{
			CustomerId = 1,
			ProductId = 1,
		};
		
		var result = validator.Validate(command);
		
		result.Errors.Count.Should().Be(0);
	}
}