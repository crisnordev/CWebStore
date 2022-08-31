using CWebStore.Domain.Entities;
using CWebStore.Domain.Queries.CategoryQueries.Interfaces;
using CWebStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CWebStore.Infra.Queries;

public class CategoryQueries : ICategoryQueries
{
    private readonly CWebStoreDbContext _context;

    public CategoryQueries(CWebStoreDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetCategories() =>
        await _context.Categories.AsNoTracking().ToListAsync();

    public async Task<Category> GetCategoryById(Guid id) =>
        await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<Category> GetCategoryByName(string name) =>
        await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryName.Name == name);

    public async Task<Category> GetCategoryProducts(Guid id) =>
        await _context.Categories.AsNoTracking().Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == id);
}