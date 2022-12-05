namespace CWebStore.Shared.ValueObjects;

public class AvailableStockValueObject : ValueObject
{
    protected AvailableStockValueObject() { }

    public AvailableStockValueObject(int availableStock)
    {
        Validate(availableStock);
        if (IsValid) AvailableStock = availableStock;
    }

    public int AvailableStock { get; private set; }
    
    public void Validate(int availableStock)
    {
        AddNotifications(new Contract<decimal>()
            .IsLowerThan(0, availableStock, "AvailableStockValueObject.AvailableStock", 
                "Available stock must not be lower than 0.")
            .IsGreaterThan(1000000, availableStock, "AvailableStockValueObject.AvailableStock", 
                "Available stock must not be greater than 1000000"));
    }

    public void EditQuantityValue(int availableStock)
    {
        Validate(availableStock);
        if (IsValid) AvailableStock = availableStock;
    }
    
    public override string ToString() => AvailableStock.ToString();
}