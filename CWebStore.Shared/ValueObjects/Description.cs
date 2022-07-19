namespace CWebStore.Shared.ValueObjects
{
    public class Description : ValueObject, IValidatable
    {
        protected  Description(){}

        public Description(string description)
        {
            DescriptionText = description;
            Validate();
        }

        public string DescriptionText { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<string>()
                .IsNotNullOrEmpty(DescriptionText, "ProductDescription.Description",
                    "Product description must not be null or empty.")
                .IsLowerThan(2, DescriptionText.Length, "ProductDescription.Description",
                    "Product description must have two or more characters.")
                .IsGreaterThan(160, DescriptionText.Length, "ProductDescription.Description",
                    "Product description must have 160 or less characters."));
        }

        public void EditDescriptionVOText(string text)
        {
            DescriptionText = text;
            Validate();
        }

        public override string ToString() => DescriptionText;
    }
}
