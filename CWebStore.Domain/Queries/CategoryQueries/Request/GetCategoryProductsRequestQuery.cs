using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Queries.CategoryQueries.Request;

public class GetCategoryProductsRequestQuery : Notifiable<Notification>, IQuery
{
    public GetCategoryProductsRequestQuery() { }
    
    [Display(Name = "Category Id")] public Guid CategoryId { get; set; }
}