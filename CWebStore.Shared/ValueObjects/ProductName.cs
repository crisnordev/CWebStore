namespace CWebStore.Shared.ValueObjects
{
    public class ProductName : ValueObject, IValidatable
    {
        protected  ProductName() {}
        
        public ProductName(string name)
        {
            Validate(name);
            if (!IsValid) return; 
            Name = name;
        }

        public string Name { get; set; }

        public void Validate(string name)
        {
            AddNotifications(new Contract<string>()
                .IsNotNullOrEmpty(name, "ProductName.Name",
                    "Product name must not be null or empty.")
                .IsLowerThan(2, name.Length, "ProductName.Name",
                    "Product name must have two or more characters.")
                .IsGreaterThan(120, name.Length, "ProductName.Name",
                    "Product name must have 120 or less characters."));
        }

        public void EditProductName(string name)
        {
            Validate(name);
            if (!IsValid) return;
            Name = name;
        }

        public override string ToString() => Name;
    }
}
