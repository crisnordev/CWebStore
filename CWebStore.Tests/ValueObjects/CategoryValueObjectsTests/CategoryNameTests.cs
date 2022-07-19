namespace CWebStore.Tests.ValueObjects.CategoryValueObjectsTests;

[TestClass]
public class CategoryNameTests
{
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_string_empty_category_name_should_return_IsNotNullOrEmpty_error_message()
    {
        var categoryName = new CategoryName(string.Empty);
        var message = "Category name must not be null or empty.";
        Assert.AreEqual(message, categoryName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_one_char_category_name_should_return_IsLowerThan_error_message()
    {
        var categoryName = new CategoryName("a");
        var message = "Category name must have two or more characters.";
        Assert.AreEqual(message, categoryName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_category_name_with_81_chars_should_return_IsGreaterThan_error_message()
    {
        var great = "aaaaaaaa10aaaaaaaa20aaaaaaaa30aaaaaaaa40";
        var categoryName = new CategoryName(great + great + "1");
        var message = "Category name must have 80 or less characters.";
        Assert.AreEqual(message, categoryName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_category_name_EditCategoryNameVOName_invalid_should_return_error_message()
    {
        var categoryName = new CategoryName("Valid Category Name");
        categoryName.EditCategoryNameVOName(string.Empty);
        var message = "Category name must not be null or empty.";
        Assert.AreEqual(message, categoryName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_category_name_should_return_IsValid()
    {
        var categoryName = new CategoryName("Valid Category Name");
        Assert.IsTrue(categoryName.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_category_name_EditCategoryNameVOName_valid_should_return_IsValid()
    {
        var categoryName = new CategoryName("Valid Category Name");
        categoryName.EditCategoryNameVOName("Another valid Category Name");
        Assert.IsTrue(categoryName.IsValid);
    }
}