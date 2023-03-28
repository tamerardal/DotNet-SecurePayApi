using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class GetCustomerDetailQuery
{
	public int CustomerID { get; set; }
	private readonly ISecurePayDbContext _context;
	private readonly IMapper _mapper;

	public GetCustomerDetailQuery(ISecurePayDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public CustomerDetailViewModel Handle()
	{
		var customer = _context.Customers.Include(p => p.Payment).SingleOrDefault(c => c.Id == CustomerID);
		
		if(customer is null)
			throw new InvalidOperationException("ID's not correct!");
			
		return _mapper.Map<CustomerDetailViewModel>(customer);
		
	}
	public class CustomerDetailViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public List<string> PurchasedGoods { get; set; }
	}
}