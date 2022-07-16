namespace CWebStore.Shared.ValueObjects;

public class Price : ValueObject, IValidatable
{
    protected Price()
    {
    }

    public Price(decimal sellValue)
    {
        SellValue = sellValue;
        Validate();
    }

    public Price(decimal buyValue, decimal percentage)
    {
        SellValue = buyValue + buyValue * percentage;
        BuyValue = buyValue;
        Percentage = percentage;
    }

    public decimal SellValue { get; private set; }

    public decimal BuyValue { get; private set; }

    public decimal Percentage { get; private set; }

    public void Validate()
    {
        AddNotifications(new Contract<decimal>()
            .IsGreaterThan(SellValue, 0m, "Price.SellValue",
                "This value must not be lower or equals 0.")
            .IsLowerThan(SellValue, 200000m, "Price.SellValue",
                "This value must not be greater than 200000.")
            .IsGreaterOrEqualsThan(BuyValue, 0m, "Price.BuyValue",
                "This value must not be lower than 0.")
            .IsLowerThan(BuyValue, 100000m, "Price.BuyValue",
                "This value must not be greater than 100000.")
            .IsGreaterOrEqualsThan(Percentage, 0m, "Price.Percentage",
                "Percentage must not be lower than 0.")
            .IsLowerThan(Percentage, 100m, "Price.Percentage",
                "Percentage must not be greater than 100."));
    }

    public void EditSellValue(decimal sellValue)
    {
        SellValue = sellValue;
        Validate();

        if (BuyValue > 0 && IsValid)
            Percentage = (SellValue - BuyValue) / BuyValue * 100;
    }

    public void EditBuyValue(decimal buyValue)
    {
        BuyValue = buyValue;
        Validate();

        if (BuyValue > 0 && Percentage > 0 && IsValid)
            SellValue = BuyValue + BuyValue * (Percentage / 100);
    }

    public void EditPercentage(decimal percentage)
    {
        Percentage = percentage;
        Validate();

        if (Percentage > 0 && BuyValue > 0 && IsValid)
            SellValue = BuyValue + BuyValue * (Percentage / 100);
    }
}