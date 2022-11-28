using CWebStore.Domain.Enums;

namespace CWebStore.Domain.Entities;

public class Customer : Entity, IValidatable
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string CompanyName { get; set; }

    public string Email { get; set; }

    public string BusinessPhone { get; set; }

    public string MobilePhone { get; set; }

    public EPersonType PersonType { get; set; }

    public string Document { get; set; }

    public string IdentityDocument { get; set; }

    public string StateRegistrationNumber { get; set; }

    public EStateRegistrationType StateRegistrationType { get; set; }

    public string CityRegistrationNumber { get; set; }

    public DateTime DateOfBirth { get; set; }

    public string Notes { get; set; }

    public List<string> Contacts { get; set; }

    public string Address { get; set; }
}