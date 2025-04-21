using Application.Cqrs.Commands;
using Entities.Factors;
using Services;

namespace Application.Factories.Command.Create;

public class CreateFactorCommand(int factorNo, DateTime factorDate, string customer, DelivaryType delivaryType, long totalPrice) : ICommand<ServiceResult>
{
	public int FactorNo { get; set; } = factorNo;
	public DateTime FactorDate { get; set; } = factorDate;
	public string Customer { get; set; } = customer;
	public DelivaryType DelivaryType { get; set; } = delivaryType;
	public long TotalPrice { get; set; } = totalPrice;
}