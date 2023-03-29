public static class Customers
{
	public static void AddCustomers(this SecurePayDbContext context)
	{
		context.Customers.AddRange(
			new Customer{Name = "Tamer", Surname = "Ardal", Email = "tamerardal@frisbe.com", Password = "tamer123"},
			new Customer{Name = "Ali", Surname = "Veli", Email = "aliveli@frisbe.com", Password = "12345678"}
		);
	}
}