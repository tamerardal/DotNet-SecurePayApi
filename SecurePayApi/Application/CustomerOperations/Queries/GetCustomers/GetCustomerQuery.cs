using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class GetCustomersQuery
{
	private readonly ISecurePayDbContext _context;
	private readonly IMapper _mapper;
	public GetCustomersQuery(ISecurePayDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public List<CustomersViewModel> Handle()
	{
		var customers = _context.Customers.Include(p => p.Payment).Where(c => c.IsActive == true).OrderBy(c => c.Id).ToList<Customer>();
		List<CustomersViewModel> viewModels = _mapper.Map<List<CustomersViewModel>>(customers);
		
		return viewModels;
	}
	
	public class CustomersViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
	}
}