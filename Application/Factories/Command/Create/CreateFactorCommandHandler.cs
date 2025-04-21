using Application.Cqrs.Commands;
using Data.Contracts;
using Entities.FactorDetails;
using Entities.Factors;
using Services;

namespace Application.Factories.Command.Create;

public class CreateFactorCommandHandler(IRepository<Factor> factorRepository,IRepository<FactorDetail> factorDetailRepository) : ICommandHandler<CreateFactorCommand, ServiceResult>
{
	public async Task<ServiceResult> Handle(CreateFactorCommand request, CancellationToken cancellationToken)
	{
		try
		{
			var factor = Factor.Create(request.FactorNo, request.FactorDate, request.Customer, request.DelivaryType, request.TotalPrice);
		
			await factorRepository.AddAsync(factor, cancellationToken);

			return ServiceResult.Ok();
		}
		catch (Exception e)
		{

			throw;
		}
	}
}
