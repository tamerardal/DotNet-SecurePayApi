using Microsoft.EntityFrameworkCore;

public class SecurePayDbContext : DbContext, ISecurePayDbContext
{
	public SecurePayDbContext(DbContextOptions<SecurePayDbContext> options) : base(options)
	{
		
	}
	public DbSet<Customer> Customers { get; set; }
	public DbSet<Payment> Payments { get; set; }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}