using System.Linq.Expressions;

namespace CWebStore.Domain.Queries;

public static class ProductQueries
{
    public static Expression<Func<Product, bool>> GetProductsInStock()
    {
        return x => x.StockAvailableStock.AvailableStock > 0;
    }
    
    public static Expression<Func<Product, bool>> GetProductsOutOfStock()
    {
        return x => x.StockAvailableStock.AvailableStock <= 0;
    }
}