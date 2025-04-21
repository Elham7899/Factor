using Entities.Common;
using Entities.Factors;
using Entities.Products;

namespace Entities.FactorDetails;

public class FactorDetail : BaseEntity
{
    //Ctors
    public FactorDetail()
    {

    }

    public FactorDetail(int factorId, int productId, string description, decimal count, int unitPrice, long sumPrice)
    {
        FactorId = factorId;
        ProductId = productId;
        Count = count;
        UnitPrice = unitPrice;
        SumPrice = sumPrice;
    }

    //Props
    /// <summary>
    /// توضیحات
    /// </summary>
    public string ProductDescription { get; set; }
    /// <summary>
    /// تعداد
    /// </summary>
    public decimal Count { get; set; }
    /// <summary>
    /// قیمت واحد
    /// </summary>
    public int UnitPrice { get; set; }
    /// <summary>
    /// قیمت کل 
    /// </summary>
    public long SumPrice { get; set; }

    //Fks
    /// <summary>
    /// شناسه فاکتور
    /// </summary>
    public int FactorId { get; set; }
    /// <summary>
    /// شناسه محصول
    /// </summary>
    public int ProductId { get; set; }

    //Navigation
    public Product Product { get; set; }
    public Factor Factor { get; set; }

    //Factory Method
    public static FactorDetail Create(int factorId, int productId, string description, decimal count, int unitPrice, long sumPrice)
        => new(factorId, productId, description, count, unitPrice, sumPrice);
}
