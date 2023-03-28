using AutoMapper;

public class CreateCustomerCommand
{
	public CreateCustomerViewModel Model { get; set; }
	private readonly ISecurePayDbContext _context;
	private readonly IMapper _mapper;

	public CreateCustomerCommand(ISecurePayDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public void Handle()
	{
		var customer = _context.Customers.SingleOrDefault(x => x.Email == Model.Email);
		
		if (customer is not null)
			throw new InvalidOperationException("Email is already used!");
			
		customer = _mapper.Map<Customer>(Model);
		
		_context.Customers.Add(customer);
		_context.SaveChanges();
	}

	public class CreateCustomerViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
	}
}