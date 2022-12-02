namespace CWebStore.Shared.ValueObjects;

public class ZipCodeValueObject : ValueObject
{
    protected ZipCodeValueObject() { }

    public ZipCodeValueObject(string zipCode)
    {
        Validate(zipCode);
        if (IsValid) ZipCode = zipCode;
    }

    public string ZipCode { get; private set; }
    
    public void Validate(string zipCode)
    {
        AddNotifications(new Contract<decimal>()
            .IsNullOrEmpty(zipCode, "ZipCodeValueObject.Code",
                "Zip code must not be null or empty.")
            .IsLowerOrEqualsThan(zipCode.Length, 8, "ZipCodeValueObject.Code",
                "Zip code must have 9 characters."));
    }

    public void EditZipCode(string zipCode)
    {
        Validate(zipCode);
        if (IsValid) ZipCode = zipCode;
    }
    
    public override string ToString() => ZipCode;
}