using Application.Cqrs.Queries;
using Application.Products.DTOs;
using Data.Contracts;
using Entities.Products;
using Microsoft.EntityFrameworkCore;
using Services;

namespace Application.Products.Query.GetAll;

public class GetAllProductQueryHandler : IQueryHandler<GetAllProductQuery, ServiceResult<List<ProductDTO>>>
{
	private readonly IRepository<Product> productRepository;

	public GetAllProductQueryHandler(IRepository<Product> repository)
	{
		productRepository = repository;
	}
	public async Task<ServiceResult<List<ProductDTO>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
    {
        var query = productRepository.Table;

        if (!string.IsNullOrEmpty(request.SearchCommand))
            query = query.Where(x => x.ProductName.Contains(request.SearchCommand));

        var productRepositories = await query.Select(x => new ProductDTO
        {
            ProductCode = x.ProductCode,
            ProductName = x.ProductName,
            Unit = x.Unit
        }).Skip((request.PageNumber - 1) * request.Count).Take(request.Count).ToListAsync();

        if (!productRepositories.Any())
            return ServiceResult.BadRequest<List<ProductDTO>>("لیستی یافت نشد");

        return ServiceResult.Ok<List<ProductDTO>>(productRepositories);
    }
}
