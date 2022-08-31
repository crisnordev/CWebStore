using CWebStore.Domain.Entities;
using CWebStore.Domain.Queries.ProductQueries.Interfaces;
using CWebStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CWebStore.Infra.Queries;

public class ProductQueries : IProductQueries
{
    private readonly CWebStoreDbContext _context;

    public ProductQueries(CWebStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetProducts() =>
        await _context.Products.AsNoTracking().ToListAsync();

    public async Task<Product> GetProductById(Guid id) =>
        await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Product> GetProductByName(string name) =>
        await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.ProductName.Name == name);

    public async Task<List<Product>> GetProductsInStock() =>
        await _context.Products.AsNoTracking().Where(x => x.StockQuantity.QuantityValue > 0).ToListAsync();

    public async Task<List<Product>> GetProductsOutStock() =>
        await _context.Products.AsNoTracking().Where(x => x.StockQuantity.QuantityValue < 0).ToListAsync();
}