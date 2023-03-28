using FluentValidation;

public class GetCustomerDetailQueryValidator : AbstractValidator<GetCustomerDetailQuery>
{
	public GetCustomerDetailQueryValidator()
	{
		RuleFor(c => c.CustomerID).GreaterThan(0);
	}
}