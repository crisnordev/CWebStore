using CWebStore.Shared.Interfaces;
using Flunt.Validations;

namespace CWebStore.Shared.ValueObjects
{
    public class Manufacturer : ValueObject, IValidatable
    {
        protected Manufacturer() {}
        
        public Manufacturer(string name)
        {
            Name = name;
            Validate();
        }

        public string Name { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<string>()
                .IsNotNullOrEmpty(Name, "Manufacturer.Name",
                    "Manufacturer name must not be null or empty.")
                .IsLowerThan(2, Name.Length, "Manufacturer.Name",
                    "Manufacturer name must have two or more characters.")
                .IsGreaterOrEqualsThan(120, Name.Length, "Manufacturer.Name",
                    "Manufacturer name must have 120 or less characters."));
        }
        
        public override string ToString() => Name;
    }
}
