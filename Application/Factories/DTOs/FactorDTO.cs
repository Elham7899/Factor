using Entities.Factors;

namespace Application.Factories.DTOs;

public class FactorDTO
{
	public int FactorNo { get; set; }
	public DateTime FactorDate { get; set; }
	public string Customer { get; set; }
	public DelivaryType DelivaryType { get; set; }
	public long TotalPrice { get; set; }
}
