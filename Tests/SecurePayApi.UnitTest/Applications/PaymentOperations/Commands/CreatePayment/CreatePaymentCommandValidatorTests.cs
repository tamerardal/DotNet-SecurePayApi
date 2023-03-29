using FluentAssertions;
using Xunit;
using static CreatePaymentCommand;

public class CreatePaymentCommandValidatorTests : IClassFixture<CommonTestFixture>
{
	CreatePaymentCommand command = new CreatePaymentCommand(null, null);
	CreatePaymentCommandValidator validator = new CreatePaymentCommandValidator();
	
	[Theory]
	[InlineData(-1, 0, "ali", "1234-1234-324-12345", 200)]
	[InlineData(0, 20, "1", "1234-1234-324-", 1000)]
	public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(int CustomerId, int ProductId, string NameSurname, string CardNumber, int CVV)
	{
		command.Model = new CreatePaymentViewModel()
		{
			CustomerId = 0,
			ProductId = 0,
			NameSurname = "",
			CardNumber = "",
			CVV = 0
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
			NameSurname = "Tamer Ardal",
			CardNumber = "4773-9205-5681-0238",
			CVV = 593
		};
		
		var result = validator.Validate(command);
		
		result.Errors.Count.Should().Be(0);
	}
}