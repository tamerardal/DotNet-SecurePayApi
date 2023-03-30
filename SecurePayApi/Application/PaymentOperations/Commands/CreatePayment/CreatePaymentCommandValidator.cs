using FluentValidation;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
	public CreatePaymentCommandValidator()
	{
		RuleFor(c => c.Model.CustomerId).GreaterThan(0).NotNull();
		RuleFor(c => c.Model.ProductId).GreaterThan(0).NotNull();
		// RuleFor(c => c.Model.CardNumber).CreditCard().NotNull();
		// RuleFor(c => c.Model.CVV).GreaterThan(400).LessThan(999).NotNull();
		// RuleFor(c => c.Model.NameSurname).MinimumLength(5).MaximumLength(40).NotNull();
	}
}