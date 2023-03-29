using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]s")]
public class ProductController : ControllerBase
{
	private readonly ISecurePayDbContext _context;
	private readonly IMapper _mapper;

	public ProductController(ISecurePayDbContext context, IMapper mapper)
	{
		_context = context;
		_mapper = mapper;
	}
	
	[HttpGet]
	public IActionResult GetProducts()
	{
		GetProductsQuery query = new GetProductsQuery(_context, _mapper);
		
		return Ok(query.Handle());
	}

}