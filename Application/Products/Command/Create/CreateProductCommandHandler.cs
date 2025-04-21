using Application.Cqrs.Commands;
using Data.Contracts;
using Entities.Products;
using Services;

namespace Application.Products.Command.Create;

public class CreateProductCommandHandler(IRepository<Product> productRepository) : ICommandHandler<CreateProductCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(request.ProductCode, request.ProductName, request.Unit);

        await productRepository.AddAsync(product, cancellationToken);

        return ServiceResult.Ok();
    }
}
