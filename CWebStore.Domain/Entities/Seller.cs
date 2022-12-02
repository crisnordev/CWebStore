using Microsoft.AspNetCore.Identity;

namespace CWebStore.Domain.Entities;

public class Seller : Entity
{
    public Seller(string id, string name) : base(id)
    {
        Name = name;
    }

    [ProtectedPersonalData]
    public string Name { get; set; }
}