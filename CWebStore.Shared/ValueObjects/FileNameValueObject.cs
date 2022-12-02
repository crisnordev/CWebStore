namespace CWebStore.Shared.ValueObjects;

public class FileNameValueObject : NameBaseValueObject
{
    protected FileNameValueObject() {}

    public FileNameValueObject(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name.ToLower().Trim());
    }

    public void Validate(string name)
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(name, "FileNameValueObject.Name",
                "File name must not be null or empty.")
            .IsLowerThan(6, name.Length, "FileNameValueObject.Name",
                "File name must have between 2 and 60 characters long.")
            .IsGreaterThan(60, name.Length, "FileNameValueObject.Name",
                "File name must have between 2 and 60 characters long."));
        
        if(!Name.EndsWith(".png") && IsValid)
            AddNotification("FileName.Name", "File must be a .png file");
    }

    public void EditFileName(string name)
    {
        Validate(name);
        if (IsValid) EditorNameBase(name.ToLower().Trim());
    }

    public override string ToString() => Name;
}
