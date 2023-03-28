using FluentValidation;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
	public CreatePaymentCommandValidator()
	{
		RuleFor(c => c.Model.CustomerId).GreaterThan(0).NotNull();
		RuleFor(c => c.Model.Title).MinimumLength(2).MaximumLength(20);
		RuleFor(c => c.Model.Price).GreaterThan(0);
	}
}