using System.ComponentModel.DataAnnotations.Schema;

public class Product
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string Title { get; set; }
	public double Price { get; set; }
	public ICollection<Payment> Payments { get; set; }
	
}