using CWebStore.Shared.Enums;

namespace CWebStore.Domain.Commands.ProductCommands;

public class CreateProductCommand : Notifiable<Notification>, ICommand
{
    protected CreateProductCommand() { }
    
    public CreateProductCommand(string id, string name, decimal value)
    {
        Validate(id, name, value);
        if (!IsValid) return;
        Id = id;
        Name = name;
        Value = value;
    }

    public CreateProductCommand(string id, string name, decimal value, string code, int availableStock, 
        string unitMeasure, string categoryId, string categoryName)
    {
        Validate(id, name, value, code, availableStock, unitMeasure, categoryId, categoryName);
        if (!IsValid) return;
        Id = id;
        Name = name;
        Value = value;
        Code = code;
        AvailableStock = availableStock;
        UnitMeasure = unitMeasure;
        CategoryId = categoryId;
        CategoryName = categoryName;
    }

    public string Id { get; set; }

    public string Name { get; set; }
    
    public decimal Value { get; set; }

    public string Code { get; set; }
    
    public int AvailableStock { get; set; }

    public string UnitMeasure { get; set; }

    public string CategoryId { get; set; }

    public string CategoryName { get; set; }
    
    public void Validate(string id, string name, decimal value)
    {
        AddNotifications(new Contract<CreateProductCommand>()
            .IsNotNullOrEmpty(id, "Entity.Id",
                "Product Id must not be null or empty.")
            .AreEquals(id, Guid.Empty, "Entity.Id",
                "Product Id must not be null or empty.")
            .IsNotNullOrEmpty(name, "ProductNameValueObject.Name",
                "Product name must not be null or empty.")
            .IsLowerThan(2, name.Length, "ProductNameValueObject.Name",
                "Product name must have between 2 and 120 characters long.")
            .IsGreaterThan(120, name.Length, "ProductNameValueObject.Name",
                "Product name must have between 2 and 120 characters long.")
            .IsGreaterOrEqualsThan(value, 0, "PriceValueObject.Value",
                "Value must not be lower than 0."));
    }

    public void Validate(string id, string name, decimal value, string code, int availableStock, string unitMeasure, 
        string categoryId, string categoryName)
    {
        AddNotifications(new Contract<object>()
            .IsNotNullOrEmpty(id, "CreateProductCommand.Id",
                "Product Id must not be null or empty.")
            .AreEquals(id, Guid.Empty, "CreateProductCommand.Id",
                "Product Id must not be null or empty.")
            .IsNotNullOrEmpty(name, "CreateProductCommand.Name",
                "Product name must not be null or empty.")
            .IsLowerThan(2, name.Length, "CreateProductCommand.Name",
                "Product name must have between 2 and 120 characters long.")
            .IsGreaterThan(120, name.Length, "CreateProductCommand.Name",
                "Product name must have between 2 and 120 characters long.")
            .IsGreaterOrEqualsThan(value, 0, "CreateProductCommand.Value",
                "Value must not be lower than 0.")
            .IsNotNullOrEmpty(code, "CreateProductCommand.Code",
                "Product code must not be null or empty.")
            .IsLowerThan(1, code.Length, "CreateProductCommand.Code",
                "Product code must have between 1 and 36 characters long.")
            .IsGreaterThan(36, code.Length, "CreateProductCommand.Code",
                "Product code must have between 1 and 36 characters long.")
            .IsLowerThan(0, availableStock, "CreateProductCommand.AvailableStock", 
                "Available stock must not be lower than 0.")
            .IsGreaterThan(1000000, availableStock, "CreateProductCommand.AvailableStock", 
                "Available stock must not be greater than 1000000")
            .IsGreaterOrEqualsThan(availableStock, 0, "CreateProductCommand.StockAvailableStock",
                "Quantity must not be lower or equals 0.")
            .IsNotNullOrEmpty(unitMeasure, "CreateProductCommand.UnitMeasure",
                "Product Id must not be null or empty.")
            .IsNotNullOrEmpty(categoryId, "CreateProductCommand.Id",
                "Product Id must not be null or empty.")
            .AreEquals(categoryId, Guid.Empty, "CreateProductCommand.Id",
                "Product Id must not be null or empty.")
            .IsNotNullOrEmpty(categoryName, "CreateProductCommand.Name",
                "Product name must not be null or empty.")
            .IsLowerThan(2, categoryName.Length, "CreateProductCommand.Name",
                "Product name must have between 2 and 60 characters long.")
            .IsGreaterThan(60, categoryName.Length, "CreateProductCommand.Name",
                "Product name must have between 2 and 60 characters long."));
    }
}