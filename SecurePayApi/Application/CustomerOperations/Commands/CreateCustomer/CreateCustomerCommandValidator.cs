using FluentValidation;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
	public CreateCustomerCommandValidator()
	{
		RuleFor(c => c.Model.Email).EmailAddress().NotEmpty();
		RuleFor(c => c.Model.Name).MinimumLength(2).MaximumLength(20).NotEmpty();
		RuleFor(c => c.Model.Surname).MinimumLength(2).MaximumLength(20).NotEmpty();
		RuleFor(c => c.Model.Password).MinimumLength(8).MaximumLength(20).NotEmpty();
		RuleFor(c => c.Model.CardNumber).CreditCard().NotNull();
		RuleFor(c => c.Model.CVV).GreaterThan(400).LessThan(999).NotNull();
	}
}