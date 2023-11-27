using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceMVC.Models;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id, bool includeCategory);
    Task CreateProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
    bool ProductExists(int id);
}
