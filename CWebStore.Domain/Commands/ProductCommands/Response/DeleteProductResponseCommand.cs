using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Commands.ProductCommands.Request;

namespace CWebStore.Domain.Commands.ProductCommands.Response;

public class DeleteProductResponseCommand : Result
{
    public DeleteProductResponseCommand() { }

    public DeleteProductResponseCommand(IProductRepository productRepository, DeleteProductRequestCommand command)
    {
        var product = productRepository.GetProductById(command.Id).Result;
        var productName = product.ProductName.Name;
        Validate(productName);
        if (!IsValid) return;

        productRepository.DeleteProduct(product);
        ProductName = productName;
        Success = true;
        Message = "Category deleted.";
    }

    [Display(Name = "Product Name")] public string ProductName { get; set; }
    
    public void Validate(string name) =>
        AddNotifications(new Contract<DeleteProductResponseCommand>()
            .IsNotNullOrEmpty(name, "DeleteProductResponseCommand.ProductName"
                , "Can not find product."));
}