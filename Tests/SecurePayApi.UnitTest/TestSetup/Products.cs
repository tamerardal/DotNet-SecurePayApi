public static class Products
{
	public static void AddProducts(this SecurePayDbContext context)
	{
		context.Products.AddRange(
			new Product{Title = "Gömlek", Price = 50},
			new Product{Title = "Çorap", Price = 20},
			new Product{Title = "Tişört", Price = 40}
		);
	}
}