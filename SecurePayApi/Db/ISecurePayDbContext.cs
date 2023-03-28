using Microsoft.EntityFrameworkCore;

public interface ISecurePayDbContext
{
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Payment> Payments { get; set; }
	public DbSet<Product> Products { get; set; }
	
	int SaveChanges();
}