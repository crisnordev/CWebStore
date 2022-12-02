using CWebStore.Shared.Enums;

namespace CWebStore.Domain.Entities;

public class Sale : Entity, IValidatable
{
    public string Number { get; set; }

    public DateTime Emission { get; set; }

    public EStatus Status { get; set; }

    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; }

    public Guid SellerId { get; set; }

    public Seller Seller { get; set; }
    
    public IList<Product> Products { get; set; }

    public DiscountValueObject Discount { get; set; }

    public Payment Payment { get; set; }
    
    
}