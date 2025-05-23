using Application.Cqrs.Commands;
using Application.Cqrs.Queries;
using Application.Products.Command.Create;
using Application.Products.DTOs;
using Application.Products.Query.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Factor.Controllers.v1;

[ApiVersion("1")]
[ApiController]
[Route("api/[controller]/[action]")]
public class ProductsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : ControllerBase
{

    [HttpPost]
    public async Task<ServiceResult> Create(ProductDTO input)
        => await commandDispatcher.SendAsync(new CreateProductCommand(input.ProductCode, input.ProductName, input.Unit));

    [HttpGet]
    public async Task<ServiceResult<List<ProductDTO>>> GetAll(int count, int pageNumber, string searchCommand)
        => await queryDispatcher.SendAsync(new GetAllProductQuery(count, pageNumber, searchCommand));
}
