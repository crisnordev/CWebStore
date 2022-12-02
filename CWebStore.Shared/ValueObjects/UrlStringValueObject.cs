namespace CWebStore.Shared.ValueObjects;

public class UrlStringValueObject : ValueObject
{
    protected UrlStringValueObject() {}
    
    public UrlStringValueObject(string url)
    {
        Validate(url);
        if (IsValid) Url = url;
    }

    public string Url { get; private set; }

    public void Validate(string url)
    {
        AddNotifications(new Contract<string>()
            .IsGreaterThan(2048, url.Length,"UrlStringValueObject.Url",
                "Url must have a maximum 2048 characters long.")
            .IsUrlOrEmpty(url, "UrlStringValueObject.Url",
                "This is not a valid Url.")
            .IsUrl(url, "UrlStringValueObject.Url",
                "This is not a valid Url."));
    }

    public void EditUrl(string url)
    {
        Validate(url);
        if (IsValid) Url = url;
    }
    
    public override string ToString() => Url;
}