namespace CWebStore.Shared.ValueObjects;

public class ProductCodeValueObject : ValueObject
{
    protected  ProductCodeValueObject() {}
        
    public ProductCodeValueObject(string code)
    {
        Validate(code);
        if (IsValid) Code = code;
    }

    public string Code { get; private set; }

    public void Validate(string code)
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(code, "ProductCodeValueObject.Code",
                "Product code must not be null or empty.")
            .IsLowerThan(1, code.Length, "ProductCodeValueObject.Code",
                "Product code must have between 1 and 36 characters long.")
            .IsGreaterThan(36, code.Length, "ProductCodeValueObject.Code",
                "Product code must have between 1 and 36 characters long."));
    }

    public void EditProductCode(string code)
    {
        Validate(code);
        if (IsValid) Code = code;
    }

    public override string ToString() => Code;
}
