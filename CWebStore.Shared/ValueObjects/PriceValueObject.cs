using System.Globalization;

namespace CWebStore.Shared.ValueObjects;

public class PriceValueObject : ValueObject
{
    protected PriceValueObject() { }

    public PriceValueObject(decimal value)
    {
        Validate(value);
        if (IsValid) Value = value;
    }

    public PriceValueObject(decimal value, decimal cost)
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
            .IsGreaterOrEqualsThan(value, 0, "PriceValueObject.Value",
                "Value must not be lower than 0."));
    }
    
    public void Validate(decimal value, decimal cost)
    {
        AddNotifications(new Contract<decimal>()
            .IsGreaterOrEqualsThan(value, 0, "PriceValueObject.Value",
                "Value must not be lower than 0.")
            .IsGreaterOrEqualsThan(cost, 0, "PriceValueObject.Cost",
                "Cost must not be lower than 0."));
    }

    public void EditValue(decimal value)
    {
        Validate(value);
        if (IsValid) Value = value;
    }

    public void EditCost(decimal cost)
    {
        Validate(cost);
        if (IsValid) Cost = cost;
    }
    
    public override string ToString() => Value.ToString("F2", CultureInfo.InvariantCulture);
}