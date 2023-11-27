using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceMVC.Models;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order> GetOrderByIdAsync(int id);
    Task CreateOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(int id);
    bool OrderExists(int id);
}
