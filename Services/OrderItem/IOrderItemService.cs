using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceMVC.Data.Models;

public interface IOrderItemService
{
    Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync();
    Task<OrderItem> GetOrderItemByIdAsync(int id);
    Task CreateOrderItemAsync(OrderItem orderItem);
    Task UpdateOrderItemAsync(OrderItem orderItem);
    Task DeleteOrderItemAsync(int id);
    bool OrderItemExists(int id);
}
