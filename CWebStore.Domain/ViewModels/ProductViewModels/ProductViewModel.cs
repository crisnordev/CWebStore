namespace CWebStore.Domain.ViewModels.ProductViewModels;

public class ProductViewModel
{
    public ProductViewModel() { }

    public ProductViewModel(Guid id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public ProductViewModel(Guid id, string name, decimal price, int stockQuantity)
    {
        Id = id;
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public static implicit operator ProductViewModel(Product product) => new()
    {
        Id = product.Id,
        Name = product.ProductName.Name,
        Price = product.Price.SellValue,
        StockQuantity = product.StockQuantity.QuantityValue
    };
}