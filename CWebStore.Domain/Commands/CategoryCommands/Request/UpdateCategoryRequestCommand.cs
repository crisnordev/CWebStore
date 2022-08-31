using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Commands.CategoryCommands.Request;

public class UpdateCategoryRequestCommand : ICommand
{
    public UpdateCategoryRequestCommand(){}

    public UpdateCategoryRequestCommand(Guid categoryId)
    {
        CategoryId = categoryId;
    }

    public UpdateCategoryRequestCommand(Guid id, string name)
    {
        CategoryId = id;
        Name = name;
    }

    [Display(Name = "Category Id")] public Guid CategoryId { get; set; }
    
    [Display(Name = "Name")]
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(2, ErrorMessage = "Category name must have two or more characters.")]
    [MaxLength(80, ErrorMessage = "Category name must have 80 or less characters.")]
    public string Name { get; set; }

    public static implicit operator UpdateCategoryRequestCommand(Guid id) => new(id);
    
    public static implicit operator UpdateCategoryRequestCommand(Category category) => 
        new(category.Id, category.CategoryName.Name);
}