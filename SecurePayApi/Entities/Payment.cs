using System.ComponentModel.DataAnnotations.Schema;

public class Payment
{
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }
	public string CardName { get; set; }
	public string CardNumber { get; set; }
	public string Name { get; set; }
	public string Surname { get; set; }
	public DateTime EndDate { get; set; }
}