using CWebStore.Domain.Entities;
using CWebStore.Domain.Repositories.Interfaces;
using CWebStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CWebStore.Infra.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly CWebStoreDbContext _context;

    public ProductRepository(CWebStoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> ProductExists(string productName) => 
        _context.Products.AsNoTracking().Select(x => x.ProductName.Name).All(x => x != productName);

    public async Task<Product> GetProductById(Guid id) =>
        await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Category> GetCategoryById(Guid id) =>
        await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    
    public async Task<Product> GetProductWithCategories(Guid id)
    {
        var product = await _context.Products.Include(x => x.Categories)
            .FirstOrDefaultAsync(x => x.Id == id);
        if (product != null) return product;
        product.AddNotification("ProductRepository.GetProductCategories", "Can not find product.");
        
        return product;
    }

    public async Task<Product> PostProduct(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
        
        return product;
    }

    public async void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async void DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}