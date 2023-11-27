using Microsoft.EntityFrameworkCore;
using ECommerceMVC.Data;
using ECommerceMVC.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class OrderItemService : IOrderItemService
{
    private readonly AppDbContext _context;

    public OrderItemService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<OrderItem>> GetAllOrderItemsAsync()
    {
        return await _context.OrderItems.Include(o => o.Order).Include(o => o.Product).ToListAsync();
    }

    public async Task<OrderItem> GetOrderItemByIdAsync(int id)
    {
        return await _context.OrderItems.Include(o => o.Order).Include(o => o.Product).FirstOrDefaultAsync(o => o.OrderId == id);
    }

    public async Task CreateOrderItemAsync(OrderItem orderItem)
    {
        _context.Add(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateOrderItemAsync(OrderItem orderItem)
    {
        _context.Update(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteOrderItemAsync(int id)
    {
        var orderItem = await _context.OrderItems.FindAsync(id);
        if (orderItem != null)
        {
            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();
        }
    }

    public bool OrderItemExists(int id)
    {
        return (_context.OrderItems?.Any(e => e.OrderId == id)).GetValueOrDefault();
    }
}
