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
		var payment = _context.Payments.SingleOrDefault(p => p.CardNumber == Model.CardNumber);
		
		if (payment is not null)
			throw new InvalidOperationException("Card number is already used!");
			
		payment = _mapper.Map<Payment>(Model);
		
		_context.Payments.Add(payment);
		_context.SaveChanges();
	}

	public class CreatePaymentViewModel
	{
		public int CustomerId { get; set; }
		public string CardName { get; set; }
		public string CardNumber { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public DateTime EndDate { get; set; }
	}
}