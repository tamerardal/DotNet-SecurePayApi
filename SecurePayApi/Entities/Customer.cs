using System.ComponentModel.DataAnnotations.Schema;

public class Customer
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public virtual ICollection<Payment> PaymentMethods { get; set; }
	public bool IsActive { get; set; } = true;
}