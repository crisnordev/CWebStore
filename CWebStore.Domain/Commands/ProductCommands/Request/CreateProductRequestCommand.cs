using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CWebStore.Domain.Commands.ProductCommands.Request;

public class CreateProductRequestCommand : Command
{
    public CreateProductRequestCommand() { }

    [Display(Name = "Name")]
    [Required(ErrorMessage = "Product name is required.")]
    [MinLength(2, ErrorMessage = "Product name must have two or more characters.")]
    [MaxLength(120, ErrorMessage = "Product name must have 120 or less characters.")]
    public string ProductName { get; set; }
    
    [Display(Name = "Sell value")]
    [Required(ErrorMessage = "Sell value is required.")]
    [Range(0, 100000)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal SellValue { get; set; }
    
    [Display(Name = "Stock quantity")]
    [Required(ErrorMessage = "Stock quantity is required.")]
    [Range(0, 100000)]
    public int StockQuantity { get; set; }
    
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
}