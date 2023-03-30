public static class Customers
{
	public static void AddCustomers(this SecurePayDbContext context)
	{
		context.Customers.AddRange(
			new Customer{Name = "Tamer", Surname = "Ardal", Email = "tamerardal@frisbe.com", Password = "tamer123", CardNumber = "4173-2201-4403-6891", CVV = 997},
				new Customer{Name = "Ali", Surname = "Veli", Email = "aliveli@frisbe.com", Password = "12345678", CardNumber = "4653-2769-0813-1442", CVV = 805}
		);
	}
}