using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Commands.CategoryCommands.Request;

public class DeleteCategoryRequestCommand : ICommand
{
    public DeleteCategoryRequestCommand(){}
    
    [Display(Name = "Category Id")] public Guid Id { get; set; }
}