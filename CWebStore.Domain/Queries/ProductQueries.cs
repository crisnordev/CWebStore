using System.Linq.Expressions;

namespace CWebStore.Domain.Queries;

public static class ProductQueries
{
    public static Expression<Func<Product, bool>> GetProductsInStock()
    {
        return x => x.StockQuantity.QuantityValue > 0;
    }
    
    public static Expression<Func<Product, bool>> GetProductsOutOfStock()
    {
        return x => x.StockQuantity.QuantityValue <= 0;
    }
}