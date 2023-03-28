using AutoMapper;
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
	
	[HttpPost]
	public IActionResult PurchasedGoods([FromBody] CreatePaymentViewModel newPayment)
	{
		CreatePaymentCommand command = new CreatePaymentCommand(_context, _mapper);
		command.Model = newPayment;
		
		command.Handle();
		return Ok();
	}
}