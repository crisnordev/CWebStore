using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Queries.ProductQueries.Request;

public class GetProductByIdRequest : Notifiable<Notification>, IQuery
{
    public GetProductByIdRequest() { }

    [Display(Name = "Product Id")] public Guid ProductId { get; set; }
}