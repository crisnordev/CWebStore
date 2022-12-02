namespace CWebStore.Shared.ValueObjects
{
    public class ProductNameValueObject : NameBaseValueObject
    {
        protected  ProductNameValueObject() {}
        
        public ProductNameValueObject(string name)
        {
            Validate(name);
            if (IsValid) EditorNameBase(name);
        }

        public void Validate(string name)
        {
            AddNotifications(new Contract<string>()
                .IsNotNullOrEmpty(name, "ProductNameValueObject.Name",
                    "Product name must not be null or empty.")
                .IsLowerThan(2, name.Length, "ProductNameValueObject.Name",
                    "Product name must have between 2 and 120 characters long.")
                .IsGreaterThan(120, name.Length, "ProductNameValueObject.Name",
                    "Product name must have between 2 and 120 characters long."));
        }

        public void EditProductName(string name)
        {
            Validate(name);
            if (IsValid) EditorNameBase(name);
        }

        public override string ToString() => Name;
    }
}
