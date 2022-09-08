using System.ComponentModel.DataAnnotations;

namespace CWebStore.Domain.Queries.ProductQueries.Request;

public class GetProductByNameRequest : Notifiable<Notification>, IQuery
{
    public GetProductByNameRequest() { }

    [Display(Name = "Product name")] public string ProductName { get; set; }
}