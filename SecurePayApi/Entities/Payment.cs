using System.ComponentModel.DataAnnotations.Schema;

public class Payment
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public int CustomerId { get; set; }
	public Customer Customer { get; set; }
	public int ProductId { get; set; }
	public Product Product { get; set; }
	public DateTime PaymentDate { get; set; } = DateTime.Now;
}