namespace CWebStore.Tests.Mocks;

public class FakeProductCategory
{
    public FakeProductCategory()
    {
        Product = new Product(new ProductName("First product"), new Price(10, 10), new Quantity(10), 
            new Description("Description"), new Manufacturer("Manufacturer"), new FileName("file.png"), 
            new UrlString("https://github.com"));
        Category = new Category(new CategoryName("Category"));
        Products = new List<Product>();
        Categories = new List<Category>();
        
        var product1 =new Product(new ProductName("Product name"), new Price(10, 10), new Quantity(10), 
            new Description("Description"), new Manufacturer("Manufacturer"), new FileName("file.png"), 
            new UrlString("https://github.com"));
        var product2 =new Product(new ProductName("Out product name"), new Price(10, 10), 
            new Quantity(0), new Description("Description"), new Manufacturer("Manufacturer"), 
            new FileName("file.png"), new UrlString("https://github.com"));
        var product3 = new Product(new ProductName("Another product name"), new Price(10, 10),
            new Quantity(10), new Description("Description"), new Manufacturer("Manufacturer"),
            new FileName("file.png"), new UrlString("https://github.com"));
        var category2 = new Category(new CategoryName("Name"));
        var category3 = new Category(new CategoryName("New category")); 
        
        
        Product.AddCategory(Category);
        product1.AddCategory(Category);
        product2.AddCategory(Category);
        product2.AddCategory(category3);
        
        Products.Add(Product);
        Products.Add(product1);
        Products.Add(product2);
        Products.Add(product3);

        Categories.Add(Category);
        Categories.Add(category2);
        Categories.Add(category3);
    }

    public Product Product { get; set; }
    
    public List<Product> Products { get; set; }

    public Category Category { get; set; }

    public List<Category> Categories { get; set; }
}