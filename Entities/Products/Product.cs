using Entities.Common;
using Entities.FactorDetails;

namespace Entities.Products;

public class Product : BaseEntity
{
    //Ctors
    public Product()
    {

    }

    public Product(string productCode, string productName, string unit)
    {
        ProductCode = productCode;
        ProductName = productName;
        Unit = unit;
    }

    //Props
    /// <summary>
    /// کد محصول
    /// </summary>
    public string ProductCode { get; set; }
    /// <summary>
    /// نام محصول
    /// </summary>
    public string ProductName { get; set; }
    /// <summary>
    /// واحد محصول
    /// </summary>
    public string Unit { get; set; }

    //Navigations
    public List<FactorDetail> FactorDetails { get; set; }

    //Factory Method
    public static Product Create(string productCode, string productName, string unit)
        => new(productCode, productName, unit);
}
