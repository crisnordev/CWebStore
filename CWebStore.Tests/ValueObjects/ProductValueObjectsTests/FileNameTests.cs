namespace CWebStore.Tests.ValueObjects.ProductValueObjectsTests;

[TestClass]
public class FileNameTests
{
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_string_empty_file_name_should_return_error_message()
    {
        var fileName = new FileName(string.Empty);
        var message = "File name must not be null or empty.";
        Assert.AreEqual(message, fileName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_one_char_file_name_should_return_IsLowerThan_error_message()
    {
        var fileName = new FileName("a");
        var message = "File name must have two or more characters.";
        Assert.AreEqual(message, fileName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_file_name_should_return_IsGreaterThan_error_message()
    {
        var great = "aaaaaaaa10aaaaaaaa20aaaaaaaa30";
        var fileName = new FileName(great + great + "1");
        var message = "File name must have 60 or less characters.";
        Assert.AreEqual(message, fileName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_file_name_which_is_not_finished_with_dot_png_should_return_error_message()
    {
        var fileName = new FileName("notFileFormat");
        var message = "File must be a .png file";
        Assert.AreEqual(message, fileName.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_file_name_EditFileName_invalid_should_return_error_message()
    {
        var fileName = new FileName("validFileName.png");
        fileName.EditFileName(string.Empty);
        var message = "File name must not be null or empty.";
        Assert.AreEqual(message, fileName.Notifications.First().Message);
    }

    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_file_name_should_return_IsValid()
    {
        var fileName = new FileName("validFileName.png");
        Assert.IsTrue(fileName.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_file_name_EditFileName_valid_should_return_IsValid()
    {
        var fileName = new FileName("validFileFormat.png");
        fileName.EditFileName("anotherValidFileFormat.png");
        Assert.IsTrue(fileName.IsValid);
    }
}