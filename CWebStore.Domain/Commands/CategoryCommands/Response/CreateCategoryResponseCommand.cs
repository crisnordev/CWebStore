using CWebStore.Domain.Commands.CategoryCommands.Request;
using CWebStore.Domain.ViewModels.CategoryViewModels;

namespace CWebStore.Domain.Commands.CategoryCommands.Response;

public class CreateCategoryResponseCommand : Result
{
    private readonly ICategoryRepository _categoryRepository;
    
    public CreateCategoryResponseCommand() { }

    public CreateCategoryResponseCommand(ICategoryRepository categoryRepository, CreateCategoryRequestCommand command)
    {
        _categoryRepository = categoryRepository;
        
        var exists = _categoryRepository.CategoryExists(command.Name).Result;
        Validate(exists);
        if (!IsValid) return;

        Category = _categoryRepository.PostCategory(new Category(command.Name)).Result;
        Success = true;
        Message = "Category created.";
    }

    public CategoryViewModel Category { get; set; }

    public void Validate(bool exists) =>
        AddNotifications(new Contract<CreateCategoryResponseCommand>()
            .IsFalse(exists, "CreateCategoryResponseCommand.Category",
                "This category already exists."));
}