using Microsoft.EntityFrameworkCore;
using ECommerceMVC.Data;
using ECommerceMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MerchantService : IMerchantService
{
    private readonly AppDbContext _context;

    public MerchantService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Merchant>> GetAllMerchantsAsync()
    {
        return await _context.Merchants.Include(m => m.Admin).ToListAsync();
    }

    public async Task<Merchant> GetMerchantByIdAsync(int id)
    {
        return await _context.Merchants.Include(m => m.Admin).FirstOrDefaultAsync(m => m.Id == id);
    }

    public async Task CreateMerchantAsync(Merchant merchant)
    {
        _context.Add(merchant);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateMerchantAsync(Merchant merchant)
    {
        _context.Update(merchant);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteMerchantAsync(int id)
    {
        var merchant = await _context.Merchants.FindAsync(id);
        if (merchant != null)
        {
            _context.Merchants.Remove(merchant);
            await _context.SaveChangesAsync();
        }
    }

    public bool MerchantExists(int id)
    {
        return (_context.Merchants?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}
