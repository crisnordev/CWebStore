namespace CWebStore.Shared.ValueObjects
{
    public class ProductName : ValueObject, IValidatable
    {
        protected  ProductName() {}
        
        public ProductName(string name)
        {
            Name = name;
            Validate();
        }

        public string Name { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<string>()
                .IsNotNullOrEmpty(Name, "ProductName.Name",
                    "Product name must not be null or empty.")
                .IsLowerThan(2, Name.Length, "ProductName.Name",
                    "Product name must have two or more characters.")
                .IsGreaterThan(120, Name.Length, "ProductName.Name",
                    "Product name must have 120 or less characters."));
        }

        public override string ToString() => Name;
    }
}
