using CWebStore.Shared.Enums;

namespace CWebStore.Shared.ValueObjects;

public class Installments : ValueObject, IValidatable
{
    public int Number { get; set; }

    public decimal Value { get; set; }

    public DateTime DueDate { get; set; }

    public EStatus Status { get; set; }

    public string Note { get; set; }

    public bool HasBillet { get; set; }
}