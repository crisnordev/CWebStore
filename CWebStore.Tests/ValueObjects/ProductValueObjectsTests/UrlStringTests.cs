using System.Text;

namespace CWebStore.Tests.ValueObjects.ProductValueObjectsTests;

[TestClass]
public class UrlStringTests
{
    private readonly UrlString _urlString;

    public UrlStringTests()
    {
        _urlString = new UrlString("https://docs.microsoft.com");
    }

    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_url_greater_than_2048_should_return_error_message()
    {
        var great = new StringBuilder("aaaaaaaa10aaaaaaaa20aaaaa32chars");
        var finalGreat = new StringBuilder("https://url.com/has26chars?");
        for (var i = 64; i > 0; i--)
            finalGreat.Append(great);
        var urlString = new UrlString(finalGreat.ToString());
        var message = "Url must have 2048 or less characters.";
        var urlStringError = urlString.Notifications.First();
        Assert.AreEqual(message, urlStringError.Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_url_empty_should_return_error_message()
    {
        var urlString = new UrlString(string.Empty);
        var message = "This is not a valid Url.";
        Assert.AreEqual(message, urlString.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_an_invalid_url_should_return_error_message()
    {
        var urlString = new UrlString("this_is_not_a_valid_url_string_test");
        var message = "This is not a valid Url.";
        Assert.AreEqual(message, urlString.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_url_EditUrlPropertyString_should_return_error_message()
    {
        _urlString.EditUrlPropertyString(string.Empty);
        var message = "This is not a valid Url.";
        Assert.AreEqual(message, _urlString.Notifications.First().Message);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_url_EditUrlPropertyString_should_return_IsValid()
    {
        _urlString.EditUrlPropertyString("https://docs.microsoft.com/isvalid");
        Assert.IsTrue(_urlString.IsValid);
    }
    
    [TestMethod]
    [TestCategory("CWebStore.Shared.ValueObjects")]
    public void Given_a_valid_url_should_return_IsValid() => Assert.IsTrue(_urlString.IsValid);
}