using Microsoft.EntityFrameworkCore;

public class DataGenerator
{
	public static void Initialize(IServiceProvider serviceProvider)
	{
		using (var context = new SecurePayDbContext(serviceProvider.GetRequiredService<DbContextOptions<SecurePayDbContext>>()))
		{
			if (context.Customers.Any())
			{
				return ;
			}
			
			context.Customers.AddRange(
				new Customer{Name = "Tamer", Surname = "Ardal", Email = "tamerardal@frisbe.com", Password = "tamer123"},
				new Customer{Name = "Ali", Surname = "Veli", Email = "aliveli@frisbe.com", Password = "12345678"}
			);
			
			context.Products.AddRange(
				new Product{Title = "Gömlek", Price = 50},
				new Product{Title = "Çorap", Price = 20},
				new Product{Title = "Tişört", Price = 40}
			);
			
			context.SaveChanges();
		}
	}
}