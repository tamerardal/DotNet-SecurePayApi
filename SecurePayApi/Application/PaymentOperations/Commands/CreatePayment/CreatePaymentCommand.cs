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
		var payment = _context.Payments.SingleOrDefault(p => p.Title == Model.Title);
		
		if (payment is not null)
			throw new InvalidOperationException("Purchased failed!");
			
		payment = _mapper.Map<Payment>(Model);
		
		_context.Payments.Add(payment);
		_context.SaveChanges();
	}

	public class CreatePaymentViewModel
	{
		public int CustomerId { get; set; }
		public string Title { get; set; }
	}
}