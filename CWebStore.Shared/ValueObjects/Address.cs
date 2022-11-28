namespace CWebStore.Shared.ValueObjects;

public class Address : ValueObject, IValidatable
{
    public string Street { get; set; }

    public string Number { get; set; }

    public string Complement { get; set; }

    public string ZipCode { get; set; }

    public string Neighborhood { get; set; }

    public City City { get; set; }

    public State State { get; set; }
}