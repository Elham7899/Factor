using Application.Cqrs.Commands;
using Application.Cqrs.Queries;
using Application.Products.Command.Create;
using Application.Products.DTOs;
using Application.Products.Query.GetAll;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Factor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : ControllerBase
    {

        [HttpPost]
        [Authorize]
        public async Task<ServiceResult> Create(ProductDTO input)
            => await commandDispatcher.SendAsync(new CreateProductCommand(input.ProductCode, input.ProductName, input.Unit));

        [HttpGet]
        public async Task<ServiceResult<List<ProductDTO>>> GetAll(int count, int pageNumber, string searchCommand)
            => await queryDispatcher.SendAsync(new GetAllProductQuery(count, pageNumber, searchCommand));
    }
}
