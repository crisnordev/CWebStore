using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Queries.ProductQueries.Request;

public class GetProductByIdRequestQuery : Notifiable<Notification>, IQuery
{
    public GetProductByIdRequestQuery() { }

    [Display(Name = "Product Id")] public Guid ProductId { get; set; }
}