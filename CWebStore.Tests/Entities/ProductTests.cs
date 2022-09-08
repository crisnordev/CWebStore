namespace CWebStore.Tests.Entities;

[TestClass]
public class ProductTests
{
    private readonly Product _product;

    private readonly Category _category;

    public ProductTests()
    {
        _product = new Product("Product name", 1, 1);
        _product.EditProductBuyValue(1.2m);
        _product.EditProductPercentage(20);
        _product.EditProductDescription("Product description");
        _product.EditProductManufacturer("Manufacturer");
        _product.EditProductFileName("fileName.png");
        _product.EditProductUrl("https://docs.microsoft.com");

        _category = new Category("Category");
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_product_with_invalid_name_should_return_error_message()
    {
        var product = new Product(string.Empty, 1, 1); 
        product.EditProductBuyValue(1.2m);
        product.EditProductPercentage(20);
        product.EditProductDescription("Product description");
        product.EditProductManufacturer("Manufacturer");
        product.EditProductFileName("fileName.png");
        product.EditProductUrl("https://docs.microsoft.com");
        
        Assert.AreEqual("Product name must not be null or empty.", 
            product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_AddCategory_with_invalid_category_should_return_error_message()
    {
        _product.AddCategory(new Category(string.Empty));
        var message = "Can not add this category.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_AddCategory_with_an_already_added_category_should_return_error_message()
    {
        _product.AddCategory(_category);
        _product.AddCategory(_category);
        var message = "This category has already been added.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_RemoveCategory_with_an_empty_guid_should_return_error_message()
    {
        _product.AddCategory(_category);
        _product.RemoveCategory(Guid.Empty);
        var message = "This id can not be null or empty.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }


    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_RemoveCategory_with_an_invalid_guid_should_return_error_message()
    {
        _product.AddCategory(_category);
        _product.RemoveCategory(new Guid("11111111-1111-1111-1111-111111111111"));
        var message = "Can not find this category.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductName_with_invalid_name_should_return_error_message()
    {
        _product.EditProductName(string.Empty);
        var message = "Product name must not be null or empty.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductSellValue_with_invalid_price_should_return_error_message()
    {
        _product.EditProductSellValue(-1);
        var message = "Sell value must not be lower than 0.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductBuyPrice_with_invalid_price_should_return_error_message()
    {
        _product.EditProductBuyValue(-1);
        var message = "Buy value must not be lower than 0.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.ValueObjects")]
    public void Given_a_product_EditProductPercentage_with_invalid_value_should_return_error_message()
    {
        _product.EditProductPercentage(-1);
        var message = "Percentage must not be lower than 0.";
        Assert.AreEqual(message, _product.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductStockQuantity_with_invalid_value_should_return_error_message()
    {
        _product.EditProductStockQuantity(-1);
        var message = "Quantity must not be lower than 0.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductDescription_with_invalid_value_should_return_error_message()
    {
        _product.EditProductDescription(string.Empty);
        var message = "Product description must not be null or empty.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductManufacturer_with_invalid_value_should_return_error_message()
    {
        _product.EditProductManufacturer(string.Empty);
        var message = "Manufacturer name must not be null or empty.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditFileName_with_invalid_value_should_return_error_message()
    {
        _product.EditProductFileName(string.Empty);
        var message = "File name must not be null or empty.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditUrlPropertyString_with_invalid_value_should_return_error_message()
    {
        _product.EditProductUrl(string.Empty);
        var message = "This is not a valid Url.";
        Assert.AreEqual(message, _product.Notifications.FirstOrDefault().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_should_return_IsValid() => Assert.IsTrue(_product.IsValid);
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_AddCategory_with_valid_category_should_return_IsValid()
    {
        _product.AddCategory(_category);
        Assert.IsTrue(_product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_AddCategory_with_valid_category_should_return_same_category_name()
    {
        _product.AddCategory(_category);
        var category = _product.Categories.FirstOrDefault();
        Assert.AreEqual("Category", category.CategoryName.Name);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_RemoveCategory_with_an_valid_guid_should_return_IsValid()
    {
        _product.AddCategory(_category);
        _product.RemoveCategory(_category.Id);
        Assert.IsTrue(_product.IsValid);
    }

    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductName_with_valid_name_should_return_IsValid()
    {
        _product.ProductName.EditProductName("New product name");
        Assert.IsTrue(_product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductSellPrice_with_valid_price_should_return_IsValid_and_percentage_correctly_calculated()
    {
        _product.Price.EditSellValue(2);
        Assert.IsTrue(_product.IsValid && _product.Price.Percentage == 100);
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductBuyPrice_with_valid_price_should_return_IsValid_and_sellValue_correctly_calculated()
    {
        _product.Price.EditBuyValue(2);
        Assert.IsTrue(_product.IsValid && _product.Price.SellValue == 2.20M);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.ValueObjects")]
    public void Given_a_product_EditProductPercentage_with_valid_value_should_return_IsValid_and_sellValue_correctly_calculated()
    {
        _product.Price.EditPercentage(20);
        Assert.IsTrue(_product.IsValid && _product.Price.SellValue == 1.20M);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductStockQuantity_with_valid_value_should_return_IsValid()
    {
        _product.StockQuantity.EditQuantityValue(1);
        Assert.IsTrue(_product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductDescription_with_valid_value_should_return_IsValid()
    {
        _product.Description.EditDescriptionText("New product description.");
        Assert.IsTrue(_product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditProductManufacturer_with_valid_value_should_return_IsValid()
    {
        _product.Manufacturer.EditManufacturerName("Valid manufacturer");
        Assert.IsTrue(_product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditFileName_with_valid_value_should_return_IsValid()
    {
        _product.ImageFileName.EditFileName("newfile.png");
        Assert.IsTrue(_product.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_valid_product_EditUrlPropertyString_with_valid_value_should_return_IsValid()
    {
        _product.ImageUrl.EditUrlPropertyString("https://docs.microsoft.com/valid");
        Assert.IsTrue(_product.IsValid);
    }
}