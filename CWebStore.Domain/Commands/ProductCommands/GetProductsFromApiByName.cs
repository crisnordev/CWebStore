namespace CWebStore.Domain.Commands.ProductCommands;

public class GetProductsFromApiByName : Notifiable<Notification>, ICommand
{
    protected GetProductsFromApiByName()
    {
    }

    public GetProductsFromApiByName(string name)
    {
        Validate(name);
        if (IsValid) Name = name;
    }

    public string Name { get; set; } 
    
    public void Validate(string name)
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(name, "ProductNameValueObject.Name",
                "Product name must not be null or empty.")
            .IsLowerThan(2, name.Length, "ProductNameValueObject.Name",
                "Product name must have between 2 and 120 characters long.")
            .IsGreaterThan(120, name.Length, "ProductNameValueObject.Name",
                "Product name must have between 2 and 120 characters long."));
    }
    
    public override string ToString() => Name;
}