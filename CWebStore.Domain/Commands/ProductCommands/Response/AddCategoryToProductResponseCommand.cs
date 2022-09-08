using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Commands.ProductCommands.Response;

public class AddCategoryToProductResponseCommand : Result
{
    private readonly IProductRepository _productRepository;
    
    public AddCategoryToProductResponseCommand() { }

    public AddCategoryToProductResponseCommand(IProductRepository productRepository, Guid productId, Guid categoryId)
    {
        _productRepository = productRepository;
        var product = _productRepository.GetProductWithCategories(productId).Result;
        Validate(product, categoryId);
        if (!IsValid) return;
        
        var category = _productRepository.GetCategoryById(categoryId).Result;
        Validate(category);
        if (!IsValid) return;
        
        product.AddCategory(category);
        _productRepository.UpdateProduct(product);

        ProductName = product.ProductName.ToString();
        CategoryName = category.CategoryName.ToString();
    }

    [Display(Name = "Product name")] public string ProductName { get; set; }
    
    [Display(Name = "Product name")] public string CategoryName { get; set; }
    
    public void Validate(Product product, Guid categoryId) =>
        AddNotifications(new Contract<AddCategoryToProductResponseCommand>()
            .IsNotNullOrEmpty(product.ProductName.ToString(), "AddCategoryToProductResponseCommand", 
                "Can not find this product.")
            .IsTrue(product.Categories.All(x => x.Id != categoryId), 
                "AddCategoryToProductResponseCommand", "This product already have this category."));

    public void Validate(Category category) =>
        AddNotifications(new Contract<AddCategoryToProductResponseCommand>()
            .IsNotNullOrEmpty(category.CategoryName.ToString(), "AddCategoryToProductResponseCommand",
                "Can not find this category."));
}