namespace CWebStore.Shared.ValueObjects;

public class State : ValueObject, IValidatable
{
    public string Name { get; set; }
}