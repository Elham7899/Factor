using System.ComponentModel.DataAnnotations;
using Entities.Common;
using Entities.FactorDetails;

namespace Entities.Factors;

public class Factor : BaseEntity<int>
{
    //Ctors
    public Factor()
    {

    }

    public Factor(int factorNo, DateTime factorDate, string customer, DelivaryType delivaryType, long totalPrice)
    {
        FactorNo = factorNo;
        FactorDate = factorDate;
        Customer = customer;
        DelivaryType = delivaryType;
        TotalPrice = totalPrice;
    }

    //Props
    /// <summary>
    /// شماره فاکتور
    /// </summary>
    public int FactorNo { get; set; }
    /// <summary>
    /// تاریخ فاکتور
    /// </summary>
    public DateTime FactorDate { get; set; }
    /// <summary>
    /// خریدار
    /// </summary>
    public string Customer { get; set; }
    /// <summary>
    /// نوع ارسال
    /// </summary>
    public DelivaryType DelivaryType { get; set; }
    /// <summary>
    /// جمع کل فاکتور
    /// </summary>
    public long TotalPrice { get; set; }

    //Navigations
    public List<FactorDetail> FactorDetails { get; set; }

    //Factory Method
    public static Factor Create(int factorNo, DateTime factorDate, string customer, DelivaryType delivaryType, long totalPrice)
        => new(factorNo, factorDate, customer, delivaryType, totalPrice);
}

public enum DelivaryType
{
    [Display(Name = "پیک")]
    Courier = 1,
    [Display(Name = "پست")]
    Post = 2,
    [Display(Name = "حضوری")]
    InPerson = 3
}