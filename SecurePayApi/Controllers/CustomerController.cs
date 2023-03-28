using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static CreateCustomerCommand;

[ApiController]
[Route("[controller]s")]
public class CustomerController : ControllerBase
{
	private readonly ISecurePayDbContext _context;
	private readonly IMapper _mapper;

	public CustomerController(ISecurePayDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	[HttpGet]
	public IActionResult GetCustomers()
	{
		GetCustomersQuery query = new GetCustomersQuery(_context, _mapper);
		
		return Ok(query.Handle());
	}
	
	[HttpGet("{id}")]
	public IActionResult GetCustomerDetail(int id)
	{
		GetCustomerDetailQuery query = new GetCustomerDetailQuery(_context, _mapper);
		query.CustomerID = id;
		
		return Ok(query.Handle());
	}

	[HttpPost]
	public IActionResult AddCustomer([FromBody] CreateCustomerViewModel newCustomer)
	{
		CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
		
		command.Model = newCustomer;
		
		CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
		validator.ValidateAndThrow(command);
		
		command.Handle();
		
		return Ok();
	}
}