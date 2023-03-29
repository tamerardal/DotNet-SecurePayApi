using FluentAssertions;
using Xunit;
using static CreateCustomerCommand;

public class CreateCustomerCommandValidatorTests : IClassFixture<CommonTestFixture>
{
	CreateCustomerCommand command = new CreateCustomerCommand(null, null);
	CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
	
	[Theory]
	[InlineData("a", "b", "tamer@co", "123", "123423-5213-1235-231")]
	[InlineData(" ", "", "tamer@", "asd", "123423--1235-231")]
	[InlineData("", " ", "tamerco@", " ", "1234-    -1234-1234")]
	[InlineData("a", "bwe", "tamer.com", "", "123423")]
	[InlineData("a", "bwe", " ", "a", "123423")]
	public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string email, string password, string cardNumber)
	{
		command.Model = new CreateCustomerViewModel()
		{
			Name = "",
			Surname = "",
			Email = "",
			Password = "",
			CardNumber = ""
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
			Email = "tamerardal@frisbe.com",
			Password = "tamer123",
			CardNumber = "4110-5193-6107-2455"
		};
		
		var result = validator.Validate(command);
		
		result.Errors.Count.Should().Be(0);
	}
}