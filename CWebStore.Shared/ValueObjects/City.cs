namespace CWebStore.Shared.ValueObjects;

public class City : ValueObject, IValidatable
{
    public string Name { get; set; }
}