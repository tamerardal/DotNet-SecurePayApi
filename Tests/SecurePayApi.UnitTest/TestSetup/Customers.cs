public static class Customers
{
	public static void AddCustomers(this SecurePayDbContext context)
	{
		context.Customers.AddRange(
			new Customer{Name = "Tamer", Surname = "Ardal", Email = "tamerardal@frisbe.com", Password = "123456", CardNumber = "4110-5193-6107-2455"},
			new Customer{Name = "Ali", Surname = "Veli", Email = "aliveli@frisbe.com", Password = "123456", CardNumber = "4844-9625-1793-5964"}
		);
	}
}