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
	public void WhenValidInputsAreGiven_Customer_ShouldBeCreated()
	{
		CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
		CreateCustomerViewModel model = new CreateCustomerViewModel()
		{
			Name = "Ömer",
			Surname = "Ardal",
			Email = "omerardal@frisbe.com",
			Password = "test1234"
		};
		
		command.Model = model;
		
		FluentActions.Invoking(() => command.Handle()).Invoke();
		
		var customer = _context.Customers.SingleOrDefault(customer => customer.Email == model.Email);
		
		customer.Should().NotBeNull();
		customer.Email.Should().Be(model.Email);
		customer.Name.Should().Be(model.Name);
		customer.Surname.Should().Be(model.Surname);
	}
}