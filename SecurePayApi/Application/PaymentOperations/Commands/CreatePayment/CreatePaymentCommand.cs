using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class CreatePaymentCommand
{
	public CreatePaymentViewModel Model { get; set; }
	private readonly ISecurePayDbContext _context;
	private readonly IMapper _mapper;

	public CreatePaymentCommand(ISecurePayDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var product = _context.Products.SingleOrDefault(p => p.Id == Model.ProductId);
		var customer = _context.Customers.SingleOrDefault(p => p.Id == Model.CustomerId);
		var cardNumber = _context.Customers.SingleOrDefault(p => p.Id == Model.CustomerId && p.CardNumber == Model.CardNumber);
		
		if(product is null && customer is null)
			throw new InvalidOperationException("Payment is already used!");
		if(cardNumber is null)
			throw new InvalidOperationException("Credit card is not belong this customer!");
			
		var result = _mapper.Map<Payment>(Model);
		result.PaymentDate = DateTime.Now;
		
		_context.Payments.Add(result);
		_context.SaveChanges();
	}

	public class CreatePaymentViewModel
	{
		public int CustomerId { get; set; }
		public int ProductId { get; set; }
		public string CardNumber { get; set; }
	}
}