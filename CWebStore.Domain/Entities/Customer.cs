using CWebStore.Shared.Enums;

namespace CWebStore.Domain.Entities;

public class Customer : Entity
{
    public Customer()
    {
    }

    public Customer(string id, string name, EPersonType personType) : base(id)
    {
        NameValueObject = new PersonNameValueObject(name);
        PersonType = personType;
    }

    public PersonNameValueObject NameValueObject { get; set; }

    public CompanyName CompanyName { get; set; }
    
    public EPersonType PersonType { get; set; }
    
    public AddressValueObject Address { get; set; }

    public void Validate()
    {
        
    }
}