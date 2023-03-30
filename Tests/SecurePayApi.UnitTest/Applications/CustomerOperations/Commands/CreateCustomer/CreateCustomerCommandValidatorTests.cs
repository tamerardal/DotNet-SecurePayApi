using FluentAssertions;
using Xunit;
using static CreateCustomerCommand;

public class CreateCustomerCommandValidatorTests : IClassFixture<CommonTestFixture>
{
	CreateCustomerCommand command = new CreateCustomerCommand(null, null);
	CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
	
	[Theory]
	[InlineData("a", "b", "tamer@co", "123", "81279386", 0)]
	[InlineData(" ", "", "tamer@", "asd", "sadj", 3)]
	[InlineData("", " ", "tamerco@", " ", "12387", 1000)]
	[InlineData("a", "bwe", "tamer.com", "", "", 1)]
	[InlineData("a", "bwe", " ", "a", "lsfdkll", 123)]
	public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string email, string password, string cardNumber, int CVV)
	{
		command.Model = new CreateCustomerViewModel()
		{
			Name = "",
			Surname = "",
			Email = "",
			Password = "",
			CardNumber = "",
			CVV = 0
		};
		
		var result = validator.Validate(command);
		
		result.Errors.Count.Should().BeGreaterThan(0);
	}
	
	[Fact]
	public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
	{
		command.Model = new CreateCustomerViewModel()
		{
			Name = "Tamer",
			Surname = "Ardal",
			Email = "tamerardal1@frisbe.com",
			Password = "tamer123",
			CardNumber = "4930-7273-8831-2857",
			CVV = 900
		};
		
		var result = validator.Validate(command);
		
		result.Errors.Count.Should().Be(0);
	}
}