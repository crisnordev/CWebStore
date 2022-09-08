namespace CWebStore.Tests.Entities;

[TestClass]
public class CategoryTests
{
    private readonly Category _category;

    public CategoryTests()
    {
        _category = new Category("Category name");
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_a_string_empty_category_name_should_return_IsNotNullOrEmpty_error_message()
    {
        var category = new Category(string.Empty);
        var message = "Category name must not be null or empty.";
        Assert.AreEqual(message, category.Notifications.First().Message);
    }

    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_a_valid_category_EditCategoryName_with_string_empty_should_return_error_message()
    {
        _category.EditCategoryName(string.Empty);
        
        Assert.AreEqual("Category name must not be null or empty.", 
            _category.Notifications.First().Message);
    }
    

    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_a_valid_category_should_return_IsValid()
    {
        Assert.IsTrue(_category.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Domain.Entities")]
    public void Given_a_valid_category_EditCategoryName_with_valid_name_should_return_IsValid()
    {
        _category.CategoryName.EditCategoryName("New category Name");
        Assert.IsTrue(_category.IsValid);
    }
}

