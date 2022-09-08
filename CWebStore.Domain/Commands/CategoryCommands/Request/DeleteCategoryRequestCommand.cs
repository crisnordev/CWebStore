using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Commands.CategoryCommands.Request;

public class DeleteCategoryRequestCommand : Command
{
    public DeleteCategoryRequestCommand(){}

    public DeleteCategoryRequestCommand(Guid id)
    {
        Validate(id);
        if (IsValid)
            CategoryId = id;
    }

    [Display(Name = "Category Id")] public Guid CategoryId { get; set; }

    public void Validate(Guid id) => AddNotifications(new Contract<DeleteCategoryRequestCommand>()
            .IsNotEmpty(id.ToString(), "DeleteCategoryRequestCommand.CategoryId", 
                "This is not a valid category id."));

    public static implicit operator DeleteCategoryRequestCommand(Guid id) => new (id);
    
    public static implicit operator Guid(DeleteCategoryRequestCommand command) => 
        new (command.CategoryId.ToString());
}