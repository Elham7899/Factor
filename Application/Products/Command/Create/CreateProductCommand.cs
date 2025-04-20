using Application.Cqrs.Commands;
using Services;

namespace Application.Products.Command.Create;

public class CreateProductCommand(string productCode, string productName, string unit) : ICommand<ServiceResult>
{
    public string ProductCode { get; set; } = productCode;
    public string ProductName { get; set; } = productName;
    public string Unit { get; set; } = unit;
}
