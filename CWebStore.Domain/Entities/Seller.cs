namespace CWebStore.Domain.Entities;

public class Seller : Entity, IValidatable
{
    public Guid SellerId { get; set; }

    public string Name { get; set; }
}