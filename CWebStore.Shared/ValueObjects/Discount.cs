using CWebStore.Shared.Enums;

namespace CWebStore.Shared.ValueObjects;

public class Discount : ValueObject, IValidatable
{
    public EMeasureUnit MeasureUnit { get; set; }

    public decimal Rate { get; set; }
}