namespace CWebStore.Shared.ValueObjects
{
    public class ProductDescription : ValueObject, IValidatable
    {
        protected  ProductDescription(){}

        public ProductDescription(string description)
        {
            Description = description;
            Validate();
        }

        public string Description { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<string>()
                .IsNotNullOrEmpty(Description, "ProductDescription.Description",
                    "Product description must not be null or empty.")
                .IsLowerThan(2, Description.Length, "ProductDescription.Description",
                    "Product description must have two or more characters.")
                .IsGreaterThan(160, Description.Length, "ProductDescription.Description",
                    "Product description must have 160 or less characters."));
        }

        public override string ToString() => Description;
    }
}
