using CWebStore.Shared.Enums;

namespace CWebStore.Shared.ValueObjects;

public class InstallmentsValueObject : ValueObject
{
    protected InstallmentsValueObject() { }

    public InstallmentsValueObject(int number, decimal value, DateTime dueDate, EStatus status, bool hasBillet)
    {
        Validate(number, value, dueDate);
        if (!IsValid) return;
        Number = number;
        Value = value;
        DueDate = dueDate;
        Status = status;
        HasBillet = hasBillet;
    }
    
    public int Number { get; private set; }

    public decimal Value { get; private set; }

    public DateTime DueDate { get; private set; }

    public EStatus Status { get; private set; }

    public bool HasBillet { get; private set; }
    
    public void Validate(int number, decimal value, DateTime dueDate)
    {
        AddNotifications(new Contract<decimal>()
            .IsGreaterOrEqualsThan(number, 0, "InstallmentsValueObject.Number",
                "Number of installments must not be lower than 0.")
            .IsGreaterOrEqualsThan(value, 0, "InstallmentsValueObject.Value",
                "Value must not be lower than 0.")
            .IsLowerThan(dueDate, DateTime.Now, "InstallmentsValueObject.DueDate",
                "This is not a valid due date."));
    }

    public void EditInstallment(int number, decimal value, DateTime dueDate, EStatus status, bool hasBillet)
    {
        Validate(number, value, dueDate);
        if (!IsValid) return;
        Number = number;
        Value = value;
        DueDate = dueDate;
        Status = status;
        HasBillet = hasBillet;
    }
}