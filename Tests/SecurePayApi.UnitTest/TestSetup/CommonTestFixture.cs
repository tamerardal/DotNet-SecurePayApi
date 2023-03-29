using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class CommonTestFixture
{
	public SecurePayDbContext Context { get; set; }
	public IMapper Mapper { get; set; }
	public CommonTestFixture()
	{
		var options = new DbContextOptionsBuilder<SecurePayDbContext>().UseInMemoryDatabase("SecurePayTestDb").Options;
		Context = new SecurePayDbContext(options);
		
		Context.Database.EnsureCreated();
		
		Context.AddProducts();
		Context.AddCustomers();
		
		Context.SaveChanges();
		
		Mapper = new MapperConfiguration(config => { config.AddProfile<MappingProfile>(); }).CreateMapper();
	}
}