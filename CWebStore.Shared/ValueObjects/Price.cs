namespace CWebStore.Shared.ValueObjects;

public class Price : ValueObject, IValidatable
{
    protected Price() { }

    public Price(decimal value)
    {
        Validate(value);
        if (!IsValid) return;

        Value = value;
    }

    public Price(decimal value, decimal cost)
    {
        Validate(value, cost);
        if (!IsValid) return;
        
        Value = value;
        Cost = cost;
    }
    
    public decimal Value { get; private set; }

    public decimal Cost { get; private set; }
    
    public void Validate(decimal value)
    {
        AddNotifications(new Contract<decimal>()
            .IsGreaterOrEqualsThan(value, 0, "Price.Value",
                "Value must not be lower than 0."));
    }
    
    public void Validate(decimal value, decimal cost)
    {
        AddNotifications(new Contract<decimal>()
            .IsGreaterOrEqualsThan(value, 0, "Price.Value",
                "Value must not be lower than 0.")
            .IsGreaterOrEqualsThan(cost, 0, "Price.Cost",
                "Cost must not be lower than 0."));
    }

    public void EditValue(decimal value)
    {
        Validate(value);
        if (!IsValid) return;
        Value = value;
    }

    public void EditCost(decimal cost)
    {
        Validate(cost);
        if (!IsValid) return;
        Cost = cost;
    }
}