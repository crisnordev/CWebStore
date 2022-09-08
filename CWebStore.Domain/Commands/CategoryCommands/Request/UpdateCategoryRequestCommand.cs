using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Commands.CategoryCommands.Request;

public class UpdateCategoryRequestCommand : Command
{
    public UpdateCategoryRequestCommand() { }

    public UpdateCategoryRequestCommand(Guid id)
    {
        Validate(id);
        if (IsValid)
            CategoryId = id;
    }

    public UpdateCategoryRequestCommand(string name)
    {
        Name = name;
    }

    [Display(Name = "Category Id")] public Guid CategoryId { get; set; }
    
    [Display(Name = "Category name")]
    [Required(ErrorMessage = "Category name is required.")]
    [MinLength(2, ErrorMessage = "Category name must have two or more characters.")]
    [MaxLength(80, ErrorMessage = "Category name must have 80 or less characters.")]
    public string Name { get; set; }
    
    public void Validate(Guid id) => AddNotifications(new Contract<UpdateCategoryRequestCommand>()
        .IsNotEmpty(id.ToString(), "UpdateCategoryRequestCommand.CategoryId", 
            "This is not a valid category id."));

    public static implicit operator UpdateCategoryRequestCommand(Guid id) => new (id);
    
    public static implicit operator Guid(UpdateCategoryRequestCommand command) => 
        new (command.CategoryId.ToString());
}