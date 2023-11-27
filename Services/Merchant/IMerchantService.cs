using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceMVC.Models;

public interface IMerchantService
{
    Task<IEnumerable<Merchant>> GetAllMerchantsAsync();
    Task<Merchant> GetMerchantByIdAsync(int id);
    Task CreateMerchantAsync(Merchant merchant);
    Task UpdateMerchantAsync(Merchant merchant);
    Task DeleteMerchantAsync(int id);
    bool MerchantExists(int id);
}
