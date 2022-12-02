namespace CWebStore.Shared.ValueObjects;

public class AddressValueObject : ValueObject, IValidatable
{
    public StreetValueObject Street { get; set; }

    public string Number { get; set; }

    public string Complement { get; set; }

    public string ZipCode { get; set; }

    public NeighborhoodValueObject Neighborhood { get; set; }

    public CityValueObject City { get; set; }

    public StateValueObject State { get; set; }
}