using Application.Cqrs.Commands;
using Entities.Factors;
using Services;

namespace Application.Factories.Command.Update;

public class UpdateFactorCommand(int id,int factorNo, DateTime factorDate, string customer, DelivaryType delivaryType, long totalPrice) : ICommand<ServiceResult>
{
	public int Id { get; set; } = id;
    public int FactorNo { get; set; } = factorNo;
	public DateTime FactorDate { get; set; } = factorDate;
	public string Customer { get; set; } = customer;
	public DelivaryType DelivaryType { get; set; } = delivaryType;
	public long TotalPrice { get; set; } = totalPrice;
}
