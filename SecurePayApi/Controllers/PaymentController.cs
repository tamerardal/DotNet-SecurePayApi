using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using static CreatePaymentCommand;

[ApiController]
[Route("[controller]s")]
public class PaymentController : ControllerBase
{
	private readonly ISecurePayDbContext _context;
	private readonly IMapper _mapper;

	public PaymentController(ISecurePayDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	[HttpGet]
	public IActionResult GetPayments()
	{
		GetPaymentsQuery query = new GetPaymentsQuery(_context, _mapper);
		
		return Ok(query.Handle());
	}

	[HttpPost]
	public IActionResult PurchasedGoods([FromBody] CreatePaymentViewModel newPayment)
	{
		CreatePaymentCommand command = new CreatePaymentCommand(_context, _mapper);
		command.Model = newPayment;
		
		CreatePaymentCommandValidator validator = new CreatePaymentCommandValidator();
		validator.ValidateAndThrow(command);
		
		command.Handle();
		return Ok();
	}
}