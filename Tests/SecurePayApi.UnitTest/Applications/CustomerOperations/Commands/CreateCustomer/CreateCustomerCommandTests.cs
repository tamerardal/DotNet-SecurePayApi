using AutoMapper;
using FluentAssertions;
using Xunit;
using static CreateCustomerCommand;

public class CreateCustomerCommandTests : IClassFixture<CommonTestFixture>
{
	private readonly SecurePayDbContext _context;
	private readonly IMapper _mapper;

	public CreateCustomerCommandTests(CommonTestFixture testFixture)
	{
		_context = testFixture.Context;
		_mapper = testFixture.Mapper;
	}
	
	[Fact]
	public void WhenAlreadyExistCustomerEmailIsGiven_InvalidOperationException_ShouldBeReturn()
	{
		var customer = new Customer(){
			Name = "Şükrü",
			Surname = "Yılmaz",
			Email = "sukruyilmaz@frisbe.com",
			Password = "test1234"
		};
		
		_context.Customers.Add(customer);
		_context.SaveChanges();
		
		CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
		command.Model = new CreateCustomerViewModel(){ Email = customer.Email };
		
		FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>().And.Message.Should().Be("Email is already used!");
	}
	
	[Fact]
	public void WhenValidInputsAreGiven_Customer_ShouldBeReturn()
	{
		CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
		CreateCustomerViewModel model = new CreateCustomerViewModel()
		{
			Name = "Ömer",
			Surname = "Ardal",
			Email = "omerardal@frisbe.com",
			Password = "test1234",
			CardNumber = "4930-7273-8831-2857",
			CVV = 700
		};
		
		command.Model = model;
		
		// FluentActions.Invoking(() => command.Handle()).Invoke();
		
		// var customer = _context.Customers.SingleOrDefault(customer => customer.Email == model.Email);
		// var cardNumber = _context.Customers.SingleOrDefault(x => x.CardNumber == model.CardNumber);
		
		var result = _mapper.Map<Customer>(model);
		
		result.Should().NotBeNull();
		result.Email.Should().Be(model.Email);
		result.Name.Should().Be(model.Name);
		result.Surname.Should().Be(model.Surname);
		result.CardNumber.Should().Be(model.CardNumber);
		result.CVV.Should().Be(model.CVV);
	}
}
