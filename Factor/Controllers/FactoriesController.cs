using Application.Cqrs.Commands;
using Application.Cqrs.Queries;
using Application.Factories.Command.Create;
using Application.Factories.Command.Update;
using Application.Factories.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Factor.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class FactoriesController(ICommandDispatcher commandDispatcher) : ControllerBase
{
	[HttpPost]
	[Authorize]
	public async Task<ServiceResult> Create(FactorDTO input)
		=> await commandDispatcher.SendAsync(new CreateFactorCommand(input.FactorNo, input.FactorDate, input.Customer, input.DelivaryType, input.TotalPrice));

	[HttpPut]
	public async Task<ServiceResult> Update(UpdateFactorDTO input)
		=> await commandDispatcher.SendAsync(new UpdateFactorCommand(input.Id, input.FactorNo, input.FactorDate, input.Customer, input.DelivaryType, input.TotalPrice));

}
