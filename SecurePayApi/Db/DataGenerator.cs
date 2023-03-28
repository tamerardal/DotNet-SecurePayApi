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
				new Customer{Name = "Tamer", Surname = "Ardal", Email = "tamerardal@frisbe.com", Password = "123456", CardNumber = "4110-5193-6107-2455"}
			);
			
			context.Payments.AddRange(
				new Payment{Title = "Gömlek", CustomerId = 1, PaymentDate = DateTime.Now, Price = 50}
			);
			
			context.SaveChanges();
		}
	}
}