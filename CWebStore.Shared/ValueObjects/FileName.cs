namespace CWebStore.Shared.ValueObjects;

public class FileName : ValueObject, IValidatable
{
    protected FileName() {}

    public FileName(string name)
    {
        Name = name.ToLower().Trim();
        Validate();
    }

    public string Name { get; private set; }

    public void Validate()
    {
        AddNotifications(new Contract<string>()
            .IsNotNullOrEmpty(Name, "FileName.Name",
                "File name must not be null or empty.")
            .IsLowerThan(6, Name.Length, "FileName.Name",
                "File name must have between 2 and 60 characters long.")
            .IsGreaterThan(60, Name.Length, "FileName.Name",
                "File name must have between 2 and 60 characters long."));
        
        if(!Name.EndsWith(".png") && IsValid)
            AddNotification("FileName.Name", "File must be a .png file");
    }

    public void EditFileName(string name)
    {
        Name = name;
        Validate();
    }

    public override string ToString() => Name;
}
