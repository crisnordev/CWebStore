using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Queries.ProductQueries.Request;

public class GetProductByNameRequestQuery : Notifiable<Notification>, IQuery
{
    public GetProductByNameRequestQuery() { }

    [Display(Name = "Product name")] public string ProductName { get; set; }
}