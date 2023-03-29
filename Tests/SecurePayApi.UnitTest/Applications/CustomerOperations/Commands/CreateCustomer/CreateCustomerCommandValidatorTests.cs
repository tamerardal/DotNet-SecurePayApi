using FluentAssertions;
using Xunit;
using static CreateCustomerCommand;

public class CreateCustomerCommandValidatorTests : IClassFixture<CommonTestFixture>
{
	CreateCustomerCommand command = new CreateCustomerCommand(null, null);
	CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
	
	[Theory]
	[InlineData("a", "b", "tamer@co", "123")]
	[InlineData(" ", "", "tamer@", "asd")]
	[InlineData("", " ", "tamerco@", " ")]
	[InlineData("a", "bwe", "tamer.com", "")]
	[InlineData("a", "bwe", " ", "a")]
	public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string name, string surname, string email, string password)
	{
		command.Model = new CreateCustomerViewModel()
		{
			Name = "",
			Surname = "",
			Email = "",
			Password = "",
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
		};
		
		var result = validator.Validate(command);
		
		result.Errors.Count.Should().Be(0);
	}
}