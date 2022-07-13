namespace CWebStore.Shared.ValueObjects;

public class Quantity : ValueObject, IValidatable
{
    protected Quantity() { }

    public Quantity(int value)
    {
        QuantityValue = value;
        Validate();
    }

    public int QuantityValue { get; private set; }
    
    public void Validate()
    {
        AddNotifications(new Contract<decimal>()
            .IsLowerThan(0, QuantityValue, "Price.Value", 
                "Quantity must not be lower or equals 0.")
            .IsGreaterThan(1000000, QuantityValue, "Price.Value", 
                "Quantity must not be greater than 1000000"));
    }

    public void EditQuantityValue(int quantity)
    {
        QuantityValue = quantity;
        Validate();
    }
}