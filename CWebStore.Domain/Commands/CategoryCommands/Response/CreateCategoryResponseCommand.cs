using CWebStore.Domain.Commands.CategoryCommands.Request;
using CWebStore.Domain.ViewModels.CategoryViewModels;

namespace CWebStore.Domain.Commands.CategoryCommands.Response;

public class CreateCategoryResponseCommand : Result
{
    public CreateCategoryResponseCommand() { }

    public CreateCategoryResponseCommand(ICategoryRepository categoryRepository, CreateCategoryRequestCommand command)
    {
        var exists = categoryRepository.CategoryExists(command.Name).Result;
        Validate(exists);
        if (!IsValid) return;

        Category = categoryRepository.PostCategory(new Category(new CategoryName(command.Name))).Result;
        Success = true;
        Message = "Category created.";
    }

    public CategoryViewModel Category { get; set; }

    public void Validate(bool exists) =>
        AddNotifications(new Contract<CreateCategoryResponseCommand>()
            .IsFalse(exists, "CreateCategoryResponseCommand.Category",
                "This category already exists."));
}