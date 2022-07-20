namespace CWebStore.Shared.ValueObjects;

public class Price : ValueObject, IValidatable
{
    protected Price() { }

    public Price(decimal sellValue)
    {
        SellValue = sellValue;
        
        Validate();
    }

    public Price(decimal buyValue, decimal percentage)
    {
        BuyValue = buyValue;
        Percentage = percentage;
        
        Validate();
        if (IsValid && Percentage > 0)
            SellValue = BuyValue + BuyValue * Percentage / 100;

        else
            SellValue = BuyValue;
    }
    
    public decimal SellValue { get; private set; }

    public decimal BuyValue { get; private set; }

    public decimal Percentage { get; private set; }

    public void Validate()
    {
        AddNotifications(new Contract<decimal>()
            .IsGreaterOrEqualsThan(SellValue,0,  "Price.SellValue", 
                "Sell value must not be lower than 0.")
            .IsGreaterOrEqualsThan(BuyValue, 0, "Price.BuyValue",
                "Buy value must not be lower than 0.")
            .IsGreaterOrEqualsThan(Percentage, 0, "Price.Percentage",
                "Percentage must not be lower than 0."));
    }

    public void EditSellValue(decimal sellValue)
    {
        SellValue = sellValue;
        Validate();
        
        if (IsValid && SellValue > BuyValue && BuyValue > 0)
            Percentage = (SellValue - BuyValue) * 100 / BuyValue;
        
        else
        {
            Percentage = 0;
            BuyValue = 0;
        }
    }

    public void EditBuyValue(decimal buyValue)
    {
        BuyValue = buyValue;
        Validate();

        if (IsValid && Percentage > 0)
            SellValue = BuyValue + BuyValue * Percentage / 100;
    }

    public void EditPercentage(decimal percentage)
    {
        Percentage = percentage;
        Validate();
        
        if (IsValid && BuyValue > 0 && Percentage > 0)
            SellValue = BuyValue + BuyValue * Percentage / 100;

        else
        {
            SellValue = 0;
        }
    }
}