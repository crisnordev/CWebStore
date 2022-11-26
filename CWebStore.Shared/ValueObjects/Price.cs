namespace CWebStore.Shared.ValueObjects;

public class Price : ValueObject, IValidatable
{
    protected Price() { }

    public Price(decimal value)
    {
        Value = value;
        
        Validate();
    }

    public Price(decimal cost, decimal percentage)
    {
        Cost = cost;
        Percentage = percentage;
        
        Validate();
        if (IsValid && Percentage > 0)
            Value = Cost + Cost * Percentage / 100;

        else
            Value = Cost;
    }
    
    public decimal Value { get; private set; }

    public decimal Cost { get; private set; }

    public decimal Percentage { get; private set; }

    public void Validate()
    {
        AddNotifications(new Contract<decimal>()
            .IsGreaterOrEqualsThan(Value,0,  "Price.Value", 
                "Value must not be lower than 0.")
            .IsGreaterOrEqualsThan(Cost, 0, "Price.Cost",
                "Cost must not be lower than 0.")
            .IsGreaterOrEqualsThan(Percentage, 0, "Price.Percentage",
                "Percentage must not be lower than 0."));
    }

    public void EditSellValue(decimal sellValue)
    {
        Value = sellValue;
        Validate();
        
        if (IsValid && Value > Cost && Cost > 0)
            Percentage = (Value - Cost) * 100 / Cost;
        
        else
        {
            Percentage = 0;
            Cost = 0;
        }
    }

    public void EditBuyValue(decimal buyValue)
    {
        Cost = buyValue;
        Validate();

        if (IsValid && Percentage > 0)
            Value = Cost + Cost * Percentage / 100;

        else
            Value = 0;
    }

    public void EditPercentage(decimal percentage)
    {
        Percentage = percentage;
        Validate();
        
        if (IsValid && Cost > 0 && Percentage > 0)
            Value = Cost + Cost * Percentage / 100;

        else
            Value = 0;
    }
}