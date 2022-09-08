namespace CWebStore.Domain.Commands.ProductCommands.Request;

public class RemoveCategoryFromProductRequestCommand
{
    public RemoveCategoryFromProductRequestCommand() { }

    public Guid Product { get; set; }

    public Guid Category { get; set; }
}