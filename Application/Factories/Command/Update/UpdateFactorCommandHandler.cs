using Application.Cqrs.Commands;
using Data.Contracts;
using Entities.Factors;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Application.Factories.Command.Update;

public class UpdateFactorCommandHandler(IRepository<Factor> factorRepository) : ICommandHandler<UpdateFactorCommand, ServiceResult>
{
	public async Task<ServiceResult> Handle(UpdateFactorCommand request, CancellationToken cancellationToken)
	{
		var factor = await factorRepository.Table.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
		if (factor == null)
			return ServiceResult.BadRequest("فاکتوری یافت نشد");

		factor.SetFactorDate(request.FactorDate);
		factor.SetDelivaryType(request.DelivaryType);
		factor.SetCustomer(request.Customer);
		factor.SetFactorNo(request.FactorNo);
		factor.SetTotalPrice(request.TotalPrice);
		factor.UpdatedAt = DateTime.Now;

		await factorRepository.UpdateAsync(factor, cancellationToken);
		return ServiceResult.Ok();
	}
}
