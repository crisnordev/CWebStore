using System.Linq.Expressions;

namespace CWebStore.Domain.Queries;

public static class ProductQueries
{
    public static Expression<Func<IList<Product>, bool>> GetProductsInStock()
    {
        return x => x.All(prod => prod.StockQuantity.QuantityValue > 0);
    }
    
    public static Expression<Func<IList<Product>, bool>> GetProductsOutOfStock()
    {
        return x => x.All(prod => prod.StockQuantity.QuantityValue == 0);
    }
}