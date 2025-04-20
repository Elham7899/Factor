using Application.Cqrs.Commands;
using Application.Cqrs.Queries;
using Application.Products.Command.Create;
using Application.Products.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Factor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(ICommandDispatcher commandDispatcher,IQueryDispatcher queryDispatcher) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO input)
            =>(await commandDispatcher.SendAsync(new CreateProductCommand(input.ProductCode,input.ProductName,input.Unit)))
    }
}
