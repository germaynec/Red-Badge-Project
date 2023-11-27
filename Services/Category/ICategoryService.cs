using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceMVC.Data.Models;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task CreateCategoryAsync(Category category);
    Task UpdateCategoryAsync(Category category);
    Task DeleteCategoryAsync(int id);
    bool CategoryExists(int id);
}
