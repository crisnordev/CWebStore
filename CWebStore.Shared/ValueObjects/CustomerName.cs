using CWebStore.Shared.Enums;

namespace CWebStore.Shared.ValueObjects;

public class CustomerName : ValueObject, IValidatable
{
    protected  CustomerName() {}
    
    public CustomerName(string name, EPersonType personType)
    {
        Validate(name);
        if (!IsValid) return;
        switch (personType)
        {
            case EPersonType.Natural:
                Name = name;
                break;
            case EPersonType.Legal:
                CompanyName = name;
                break;
        }
    }

    public string Name { get; private set; } = string.Empty;

    public string CompanyName { get; private set; } = string.Empty;

    public void Validate(string name)
    {
        AddNotifications(new Contract<Notification>()
            .IsNotNullOrEmpty(name, "CustomerName.Name",
                "Customer Name must not be null or empty.")
            .IsLowerThan(2, name.Length, "CustomerName.Name",
                "Customer Name must have between 2 and 160 characters long.")
            .IsGreaterOrEqualsThan(160, name.Length, "CustomerName.Name",
                "Customer Name must have between 2 and 160 characters long."));
    }

    public void EditCustomerName(string name, EPersonType personType)
    {
        Validate(name);
        if (!IsValid) return;
        switch (personType)
        {
            case EPersonType.Natural:
                Name = name;
                break;
            case EPersonType.Legal:
                CompanyName = name;
                break;
        }
    }

    public override string ToString() => Name switch
        {
            "" => CompanyName,
            not "" => Name
        };
}