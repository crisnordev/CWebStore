using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Commands.ProductCommands.Request;

public class DeleteProductRequestCommand : Notifiable<Notification>, ICommand
{
    public DeleteProductRequestCommand() { }
    
    [Display(Name = "Product Id")] public Guid Id { get; set; }
}