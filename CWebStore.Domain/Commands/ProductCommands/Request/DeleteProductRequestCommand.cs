using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Commands.ProductCommands.Request;

public class DeleteProductRequestCommand : Command
{
    public DeleteProductRequestCommand() { }

    public DeleteProductRequestCommand(Guid id)
    {
        Id = id;
    }

    [Display(Name = "Product Id")] public Guid Id { get; set; }
    
    
    
    public static implicit operator DeleteProductRequestCommand(Guid id) => new(id);
    
    public static implicit operator Guid(DeleteProductRequestCommand id) => new(id.ToString());
}