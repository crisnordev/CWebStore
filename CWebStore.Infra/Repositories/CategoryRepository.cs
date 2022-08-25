using CWebStore.Domain.Entities;
using CWebStore.Domain.Repositories.Interfaces;
using CWebStore.Infra.Data;
using CWebStore.Shared;
using Microsoft.EntityFrameworkCore;

namespace CWebStore.Infra.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly CWebStoreDbContext _context;
    
    public CategoryRepository(CWebStoreDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CategoryExists(string categoryName) =>
        _context.Categories.AsNoTracking().Select(x => x.CategoryName.Name).All(x => x != categoryName);
    
    public async Task<IEnumerable<Category>> GetAllCategories() => 
        await _context.Categories.ToListAsync();

    public async Task<Category> GetCategoryById(Guid id) =>
        await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        
    public async Task<Category> PostCategory(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        
        return category;
    }

    public async Task<Category> UpdateCategory(Category category)
    {
        _context.Entry(category).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        
        return category;
    }

    public async Task<Category> DeleteCategory(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        
        return category;
    }
}