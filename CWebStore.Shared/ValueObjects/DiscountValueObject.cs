using System.Globalization;
using CWebStore.Shared.Enums;

namespace CWebStore.Shared.ValueObjects;

public class DiscountValueObject : ValueObject
{
    protected DiscountValueObject()
    {
    }
    
    protected DiscountValueObject(EValueMeasureUnit valueMeasureUnit, decimal rate)
    {
        Validate(rate);
        if (!IsValid) return;
        ValueMeasureUnit = valueMeasureUnit;
        Rate = rate;
    }

    public EValueMeasureUnit ValueMeasureUnit { get; private set; }

    public decimal Rate { get; private set; }
    
    public void Validate(decimal rate)
    {
        AddNotifications(new Contract<decimal>()
            .IsGreaterOrEqualsThan(rate, 0, "PriceValueObject.Value",
                "Value must not be lower than 0."));
    }

    public void EditMeasureUnit(EValueMeasureUnit valueMeasureUnit) 
    {
        if (IsValid) ValueMeasureUnit = valueMeasureUnit;
    }

    public void EditRate(decimal rate)
    {
        Validate(rate);
        if (IsValid) Rate = rate;
    }
    
    public override string ToString() => Rate.ToString("F2", CultureInfo.InvariantCulture);
}