namespace CWebStore.Shared.ValueObjects;

public class NameBaseValueObject : ValueObject
{
    protected  NameBaseValueObject() {}

    public string Name { get; private set; }


    public void EditorNameBase(string name)
    {
        if (IsValid) Name = name;
    }

    public override string ToString() => Name;
}