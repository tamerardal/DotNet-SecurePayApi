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
				new Customer{Name = "Tamer", Surname = "Ardal", Email = "tamerardal@frisbe.com", Password = "123456"}
			);
			
			context.Payments.AddRange(
				new Payment{CustomerId = 1, CardName = "Yapıkredi Kartım", CardNumber = "1234123412341234", Name = "Tamer", Surname = "Ardal", EndDate = DateTime.Now.AddYears(5)}
			);
			
			context.SaveChanges();
		}
	}
}