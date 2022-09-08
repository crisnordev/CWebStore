using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CWebStore.Domain.Commands.ProductCommands.Request;

public class UpdateProductRequestCommand : Notifiable<Notification>, ICommand
{
    public UpdateProductRequestCommand() { }

    public UpdateProductRequestCommand(Guid id)
    {
        Validate(id);
        if (IsValid)
            ProductId = id;
    }

    public UpdateProductRequestCommand(Guid id, string productName, string productDescription, string manufacturerName, decimal sellValue, decimal buyValue, decimal percentage, int stockQuantity, string imageFileName, string imageUrl)
    {
        if (IsValid)
            ProductId = id;
        ProductName = productName;
        ProductDescription = productDescription;
        ManufacturerName = manufacturerName;
        SellValue = sellValue;
        BuyValue = buyValue;
        Percentage = percentage;
        StockQuantity = stockQuantity;
        ImageFileName = imageFileName;
        ImageUrl = imageUrl;
    }

    [Display(Name = "Product Id")] public Guid ProductId { get; set; }
    
    [Display(Name = "Name")]
    [Required(ErrorMessage = "Product name is required.")]
    [MinLength(2, ErrorMessage = "Product name must have two or more characters.")]
    [MaxLength(120, ErrorMessage = "Product name must have 120 or less characters.")]
    public string ProductName { get; set; }
    
    [Display(Name = "Description")]
    [Required(ErrorMessage = "Product description is required.")]
    [MinLength(2, ErrorMessage = "Product description must have two or more characters.")]
    [MaxLength(120, ErrorMessage = "Product description must have 160 or less characters.")]
    public string ProductDescription { get; set; }
    
    [Display(Name = "Manufacturer")]
    [Required(ErrorMessage = "Manufacturer is required.")]
    [MinLength(2, ErrorMessage = "Product Manufacturer must have two or more characters.")]
    [MaxLength(80, ErrorMessage = "Product Manufacturer must have 80 or less characters.")]
    public string ManufacturerName { get; set; }
    
    [Display(Name = "Sell value")]
    [Required(ErrorMessage = "Sell value is required.")]
    [Range(0, 100000)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal SellValue { get; set; }

    [Display(Name = "Buy value")]
    [Required(ErrorMessage = "Buy value is required.")]
    [Range(0, 100000)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal BuyValue { get; set; }

    [Display(Name = "Percentage")]
    [Required(ErrorMessage = "Percentage value is required.")]
    [Range(0, 100)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Percentage { get; set; }
    
    [Display(Name = "Stock quantity")]
    [Required(ErrorMessage = "Stock quantity is required.")]
    [Range(0, 100000)]
    public int StockQuantity { get; set; }

    [Display(Name = "Image file name")]
    [Required(ErrorMessage = "Image file name is required."), 
     FileExtensions(Extensions = "png",ErrorMessage = "File extension must be .png.")]
    [MinLength(6, ErrorMessage = "Image file name must have two or more characters.")]
    [MaxLength(60, ErrorMessage = "Image file name must have 60 or less characters.")]
    public string ImageFileName { get; set; } = ".png";

    [Display(Name = "Image Url")]
    [Required(ErrorMessage = "Image Url is required.")]
    [MaxLength(120, ErrorMessage = "Image Url must have 120 or less characters.")]
    [Url(ErrorMessage = "This is no a valid Url.")]
    public string ImageUrl { get; set; }
    
    public void Validate(Guid id) => AddNotifications(new Contract<UpdateProductRequestCommand>()
        .IsNotEmpty(id.ToString(), "UpdateCategoryRequestCommand.CategoryId", 
            "This is not a valid category id."));
    
    public static implicit operator UpdateProductRequestCommand(Guid id) => new(id);
    
    public static implicit operator Guid(UpdateProductRequestCommand id) => new(id.ProductId.ToString());
}