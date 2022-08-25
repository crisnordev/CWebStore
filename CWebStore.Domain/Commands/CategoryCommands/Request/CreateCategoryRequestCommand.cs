using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Commands.CategoryCommands.Request;

public class CreateCategoryRequestCommand : Notifiable<Notification>, ICommand
{
    public CreateCategoryRequestCommand() { }

    public CreateCategoryRequestCommand(string name)
    {
        Name = name;
    }

    [Display(Name = "Name")]
    [Required(ErrorMessage = "Name is required.")]
    [MinLength(2, ErrorMessage = "Category name must have two or more characters.")]
    [MaxLength(80, ErrorMessage = "Category name must have 80 or less characters.")]
    public string Name { get; set; }
    
}