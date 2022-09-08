using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Commands.ProductCommands.Request;
using CWebStore.Domain.ViewModels.ProductViewModels;

namespace CWebStore.Domain.Commands.ProductCommands.Response;

public class UpdateProductResponseCommand : Result
{
    private readonly IProductRepository _productRepository;
    
    public UpdateProductResponseCommand() { }

    public UpdateProductResponseCommand(IProductRepository productRepository, UpdateProductRequestCommand command)
    {
        _productRepository = productRepository;
        
        var product = _productRepository.GetProductById(command.ProductId).Result;
        Validate(product.ProductName.Name);
        if (!IsValid) return;
        
        product.EditProductName(command.ProductName);
        product.EditProductSellValue(command.SellValue);
        product.EditProductBuyValue(command.BuyValue);
        product.EditProductPercentage(command.Percentage);
        product.EditProductStockQuantity(command.StockQuantity);
        product.EditProductDescription(command.ProductDescription);
        product.EditProductManufacturer(command.ManufacturerName);
        product.EditProductFileName(command.ImageFileName);
        product.EditProductUrl(command.ImageUrl);
        AddNotifications(product);
        if (!IsValid) return;
        
        _productRepository.UpdateProduct(product);
        ProductName = product.ProductName.Name;
        Success = true;
        Message = "Product updated.";
    }
    
    [Display(Name = "Product Name")] public string ProductName { get; set; }
    
    public void Validate(string name) =>
        AddNotifications(new Contract<UpdateProductResponseCommand>()
            .IsNotNullOrEmpty(name, "UpdateCategoryResponseCommand.CategoryName", 
                "Can not find category."));
}