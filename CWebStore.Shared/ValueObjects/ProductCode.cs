namespace CWebStore.Shared.ValueObjects;

public class ProductCode : ValueObject, IValidatable
{
    protected  ProductCode() {}
        
    public ProductCode(string code)
    {
        Validate(code);
        if (!IsValid) return; 
        Code = code;
    }

    public string Code { get; set; }

    public void Validate(string code)
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(code, "ProductCode.Code",
                "Product code must not be null or empty.")
            .IsLowerThan(1, code.Length, "ProductCode.Code",
                "Product code must have between 1 and 36 characters long.")
            .IsGreaterThan(36, code.Length, "ProductCode.Code",
                "Product code must have between 1 and 36 characters long."));
    }

    public void EditCode(string code)
    {
        Validate(code);
        if (!IsValid) return;
        Code = code;
    }

    public override string ToString() => Code;
}
