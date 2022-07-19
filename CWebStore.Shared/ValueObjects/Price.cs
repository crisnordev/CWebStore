namespace CWebStore.Shared.ValueObjects;

public class Price : ValueObject, IValidatable
{
    protected Price() { }

    public Price(decimal sellValue)
    {
        SellValue = sellValue;
        
        Validate();
    }

    public decimal SellValue { get; private set; }

    public decimal BuyValue { get; private set; } 

    public decimal Percentage { get; private set; }

    public void Validate()
    {
        AddNotifications(new Contract<decimal>()
            .IsLowerOrEqualsThan(0.00m, SellValue, "Price.SellValue", 
                "Sell value must not be lower or equals 0.")
            .IsGreaterThan(200000.00m, SellValue, "Price.SellValue", 
                "Sell value must not be greater than 200000.")
            .IsLowerThan(0.00m, BuyValue, "Price.BuyValue",
                "Buy value must not be lower than 0.")
            .IsGreaterThan(100000.00m, BuyValue, "Price.BuyValue",
                "Buy value must not be greater than 100000.")
            .IsLowerThan(0.00m, Percentage, "Price.Percentage",
                "Percentage must not be lower than 0.")
            .IsGreaterThan(100.00m, Percentage, "Price.Percentage",
                "Percentage must not be greater than 100."));
        
        if (BuyValue > 0 || Percentage > 0)
            AddNotifications(new Contract<decimal>()
                .IsLowerOrEqualsThan(0.00m, Percentage, "Price.EditBuyValue",
                    "Percentage must have a value greater than 0.")
                .IsLowerOrEqualsThan(0.00m, BuyValue, "Price.EditPercentage",
                    "Buy price must have a value greater than 0."));
    }

    public void EditSellValue(decimal sellValue)
    {
        SellValue = sellValue;
        BuyValue = 0;
        Percentage = 0;
        
        Validate();
    }

    public void EditBuyValue(decimal buyValue, decimal percentage)
    {
        BuyValue = buyValue;
        Percentage = percentage;
        SellValue = BuyValue + BuyValue * (Percentage / 100);
        
        Validate();
    }

    public void EditPercentage(decimal buyValue, decimal percentage)
    {
        BuyValue = buyValue;
        Percentage = percentage;
        SellValue = BuyValue + BuyValue * (Percentage / 100);
        
        Validate();
    }
}