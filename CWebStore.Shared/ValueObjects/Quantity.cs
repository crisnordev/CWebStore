namespace CWebStore.Shared.ValueObjects;

public class Quantity : ValueObject, IValidatable
{
    protected Quantity() { }

    public Quantity(int value)
    {
        AvailableStock = value;
        Validate();
    }

    public int AvailableStock { get; private set; }
    
    public void Validate()
    {
        AddNotifications(new Contract<decimal>()
            .IsLowerThan(0, AvailableStock, "Price.Value", 
                "Available stock must not be lower than 0.")
            .IsGreaterThan(1000000, AvailableStock, "Price.Value", 
                "Available stock must not be greater than 1000000"));
    }

    public void EditQuantityValue(int quantity)
    {
        AvailableStock = quantity;
        Validate();
    }
}