using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Commands.ProductCommands.Request;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Commands.ProductCommands.Response;

public class CreateProductResponseCommand : Result
{
    private readonly IProductRepository _productRepository;
    
    public CreateProductResponseCommand() { }

    public CreateProductResponseCommand(IProductRepository productRepository, CreateProductRequestCommand command)
    {
        _productRepository = productRepository;
        
        var exists = _productRepository.ProductExists(command.ProductName).Result;
        Validate(exists);
        if (!IsValid) return;

        var product = new Product(command.ProductName, command.SellValue, command.StockQuantity) ;
        if (!string.IsNullOrEmpty(command.ProductDescription))
        {
            product.EditProductBuyValue(command.BuyValue);
            product.EditProductPercentage(command.Percentage);
            product.EditProductDescription(command.ProductDescription);
            product.EditProductManufacturer(command.ManufacturerName);
            product.EditProductFileName(command.ImageFileName);
            product.EditProductUrl(command.ImageUrl);
        }
        
        Product = _productRepository.PostProduct(product).Result;
        Success = true;
        Message = "Product created.";
    }
    
    
    [Display(Name = "Name")] public ProductViewModel Product { get; private set; }
    
    public void Validate(bool exists) =>
        AddNotifications(new Contract<CreateProductResponseCommand>()
            .IsFalse(exists, "CreateProductResponseCommand.Product", "This product already exists."));
}