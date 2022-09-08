using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Queries.CategoryQueries.Request;

public class GetCategoryProductsRequest : Notifiable<Notification>, IQuery
{
    public GetCategoryProductsRequest() { }
    
    [Display(Name = "Category Id")] public Guid CategoryId { get; set; }
}