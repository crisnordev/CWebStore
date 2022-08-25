using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Commands.CategoryCommands.Response;

namespace CWebStore.Domain.Commands.ProductCommands.Response;

public class CreateProductResponseCommand : Notifiable<Notification>, IResult
{
    public CreateProductResponseCommand() { }


    public CreateProductResponseCommand(Product product)
    {
        ProductId = product.Id;
        Name = product.ProductName.Name;
        Price = product.Price.SellValue;
        StockQuantity = product.StockQuantity.QuantityValue;
    }

    [Display(Name = "Product Id")] public Guid ProductId { get; set; }
    
    [Display(Name = "Name")] public string Name { get; private set; }

    [Display(Name = "Price")] public decimal Price { get; private set; }

    [Display(Name = "Stock quantity")] public int StockQuantity { get; private set; }

    public static implicit operator CreateProductResponseCommand(Product product) =>
        new()
        {
            ProductId = product.Id,
            Name = product.ProductName.Name,
            Price = product.Price.SellValue,
            StockQuantity = product.StockQuantity.QuantityValue
        };
}