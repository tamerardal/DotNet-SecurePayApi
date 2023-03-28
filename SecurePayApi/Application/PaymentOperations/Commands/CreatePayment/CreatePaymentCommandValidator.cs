using FluentValidation;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
	public CreatePaymentCommandValidator()
	{
		RuleFor(c => c.Model.CustomerId).GreaterThan(0).NotNull();
		RuleFor(c => c.Model.ProductId).GreaterThan(0).NotNull();
		
	}
}