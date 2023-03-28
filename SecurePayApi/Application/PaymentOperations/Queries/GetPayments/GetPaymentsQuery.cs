using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class GetPaymentsQuery
{
	private readonly ISecurePayDbContext _context;
	private readonly IMapper _mapper;

	public GetPaymentsQuery(ISecurePayDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}

	public List<PaymentListViewModel> Handle()
	{
		var payments = _context.Payments.Include(p => p.Customer).Include(p => p.Product).OrderBy(p => p.PaymentDate).ToList();
		List<PaymentListViewModel> viewModels = _mapper.Map<List<PaymentListViewModel>>(payments);
		
		return viewModels;
	}
	
	public class PaymentListViewModel
	{
		public string Customer { get; set; }
		public string Product { get; set; }
		public string PaymentDate { get; set; }
	}
}