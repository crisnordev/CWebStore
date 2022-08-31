using System.ComponentModel.DataAnnotations;
using CWebStore.Domain.Commands.CategoryCommands.Request;

namespace CWebStore.Domain.Commands.CategoryCommands.Response;

public class DeleteCategoryResponseCommand : Result
{
    public DeleteCategoryResponseCommand() { }

    public DeleteCategoryResponseCommand(ICategoryRepository categoryRepository, DeleteCategoryRequestCommand command)
    {
        var category = categoryRepository.GetCategoryById(command.Id).Result;
        var categoryName = category.CategoryName.Name;
        Validate(categoryName);
        if (!IsValid) return;

        categoryRepository.DeleteCategory(category);
        CategoryName = categoryName;
        Success = true;
        Message = "Category deleted.";
    }

    [Display(Name = "Category Name")] public string CategoryName { get; set; }

    public void Validate(string name) =>
        AddNotifications(new Contract<DeleteCategoryResponseCommand>()
            .IsNotNullOrEmpty(name, "DeleteCategoryResponseCommand.CategoryName"
                , "Can not find category."));
}