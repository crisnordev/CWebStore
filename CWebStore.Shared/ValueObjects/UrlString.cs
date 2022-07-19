namespace CWebStore.Shared.ValueObjects;

public class UrlString : ValueObject, IValidatable
{
    protected UrlString() {}
    
    public UrlString(string urlString)
    {
        UrlStringProperty = urlString;
        Validate();
    }

    public string UrlStringProperty { get; private set; }

    public void Validate()
    {
        AddNotifications(new Contract<string>()
            .IsGreaterThan(2048, UrlStringProperty.Length,"UrlString.UrlStringProperty",
                "Url must have 2048 or less characters.")
            .IsUrlOrEmpty(UrlStringProperty, "UrlString.UrlStringProperty",
                "This is not a valid Url.")
            .IsUrl(UrlStringProperty, "UrlString.UrlStringProperty",
                "This is not a valid Url."));
    }

    public void EditUrlStringProperty(string url)
    {
        UrlStringProperty = url;
        Validate();
    }
    
    public override string ToString() => UrlStringProperty;
}