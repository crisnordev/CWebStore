namespace CWebStore.Domain.Commands.ProductCommands.Request;

public class AddCategoryToProductRequestCommand : Command
{
    public AddCategoryToProductRequestCommand() { }

    public Guid ProductId { get; set; }

    public Guid CategoryId { get; set; }
}