using AutoMapper;

public class GetProductsQuery
{
	private readonly ISecurePayDbContext _context;
	private readonly IMapper _mapper;

	public GetProductsQuery(ISecurePayDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	public List<GetProductsViewModel> Handle()
	{
		var products = _context.Products.OrderBy(p => p.Id).ToList<Product>();
		List<GetProductsViewModel> viewModels = _mapper.Map<List<GetProductsViewModel>>(products);
		
		return viewModels;
	}
	
	public class GetProductsViewModel
	{
		public string Title { get; set; }
		public string Price { get; set; }
	}
}