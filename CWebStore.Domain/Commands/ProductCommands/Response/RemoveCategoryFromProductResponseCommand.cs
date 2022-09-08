using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Commands.ProductCommands.Response;

public class RemoveCategoryFromProductResponseCommand : Result
{
    private readonly IProductRepository _productRepository;

    public RemoveCategoryFromProductResponseCommand() { }

    public RemoveCategoryFromProductResponseCommand(IProductRepository productRepository, Guid productId, Guid categoryId)
    {
        _productRepository = productRepository;
            var product = _productRepository.GetProductWithCategories(productId).Result;
        product.RemoveCategory(categoryId);
        Validate(product);
        if (!IsValid) return;

        _productRepository.UpdateProduct(product);

        ProductName = product.ProductName.ToString();
        CategoryName = product.Categories.FirstOrDefault(x => x.Id == categoryId).CategoryName.ToString();
    }

    [Display(Name = "Product name")] public string ProductName { get; set; }
    
    [Display(Name = "Product name")] public string CategoryName { get; set; }
    
    public void Validate(Product product) =>
        AddNotifications(new Contract<RemoveCategoryFromProductResponseCommand>()
            .IsNotNullOrEmpty(product.ProductName.ToString(), "RemoveCategoryFromProductResponseCommand", 
                "Can not find this product.").Join(product));
}
    
