using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Commands.CategoryCommands.Request;

namespace CWebStore.Domain.Commands.CategoryCommands.Response;

public class UpdateCategoryResponseCommand : Result
{
    private readonly ICategoryRepository _categoryRepository;
    
    public UpdateCategoryResponseCommand() { }
    
    public UpdateCategoryResponseCommand(ICategoryRepository categoryRepository, UpdateCategoryRequestCommand command)
    {
        _categoryRepository = categoryRepository;
        
        var category = _categoryRepository.GetCategoryById(command).Result;
        Validate(command.Name);
        if (!IsValid) return;

        category.EditCategoryName(command.Name);
        AddNotifications(category);
        if (!IsValid) return;
        
        _categoryRepository.UpdateCategory(category);
        CategoryName = command.Name;
        Success = true;
        Message = "Category deleted.";
    }

    [Display(Name = "Name")] public string CategoryName { get; set; }

    public void Validate(string name) =>
        AddNotifications(new Contract<UpdateCategoryResponseCommand>()
            .IsNotNullOrEmpty(name, "UpdateCategoryResponseCommand.CategoryName"
                , "Can not find category."));
}