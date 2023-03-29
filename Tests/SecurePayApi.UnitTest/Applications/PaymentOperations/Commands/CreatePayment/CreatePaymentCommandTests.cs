using AutoMapper;
using FluentAssertions;
using Xunit;
using static CreatePaymentCommand;

public class CreatePaymentCommandTests : IClassFixture<CommonTestFixture>
{
	private readonly SecurePayDbContext _context;
	private readonly IMapper _mapper;

	public CreatePaymentCommandTests(CommonTestFixture testFixture)
	{
		_context = testFixture.Context;
		_mapper = testFixture.Mapper;
	}

	[Fact]
	public void WhenValidInputsAreGiven_Payment_ShouldBeReturn()
	{
		CreatePaymentCommand command = new CreatePaymentCommand(_context, _mapper);
		CreatePaymentViewModel model = new CreatePaymentViewModel()
		{
			CustomerId = 1,
			ProductId = 1,
			NameSurname = "Tamer Ardal",
			CardNumber = "4773-9205-5681-0238",
			CVV = 600
		};
		
		command.Model = model;
		
		FluentActions.Invoking(() => command.Handle()).Invoke();
		
		var product = _context.Products.SingleOrDefault(p => p.Id == model.ProductId);
		var customer = _context.Customers.SingleOrDefault(p => p.Id == model.CustomerId);
		
		var result = _mapper.Map<Payment>(model);
		
		result.Should().NotBeNull();
		result.CustomerId.Should().Be(model.CustomerId);
		result.ProductId.Should().Be(model.ProductId);
		result.CardNumber.Should().Be(model.CardNumber);
		result.CVV.Should().Be(model.CVV);
		result.NameSurname.Should().Be(model.NameSurname);
	}
	
}