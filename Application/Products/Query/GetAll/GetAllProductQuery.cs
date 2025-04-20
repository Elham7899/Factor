using Application.Cqrs.Queries;
using Application.Products.DTOs;
using Services;

namespace Application.Products.Query.GetAll;

public class GetAllProductQuery : IQuery<ServiceResult<List<ProductDTO>>>
{
    public GetAllProductQuery(int count, int pageNumber,string searchCommand)
    {
        Count = count;
        PageNumber = pageNumber;
        SearchCommand = searchCommand;
    }
    public int Count { get; set; }
    public int PageNumber { get; set; }
    public string SearchCommand { get; set; }
}
