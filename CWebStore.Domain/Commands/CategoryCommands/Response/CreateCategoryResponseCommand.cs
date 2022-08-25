using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Commands.CategoryCommands.Request;
using CWebStore.Domain.Entities;

namespace CWebStore.Domain.Commands.CategoryCommands.Response;

public class CreateCategoryResponseCommand : Notifiable<Notification>, IResult
{
    public CreateCategoryResponseCommand() { }

    public CreateCategoryResponseCommand(Category category)
    {
        CategoryId = category.Id;
        Name = category.CategoryName.Name;
    }

    [Display(Name = "Category Id")] public Guid CategoryId { get; set; }

    [Display(Name = "Name")] public string Name { get; set; }

    public static implicit operator CreateCategoryResponseCommand(Category category) =>
        new()
        {
            CategoryId = category.Id,
            Name = category.CategoryName.Name
        };
}