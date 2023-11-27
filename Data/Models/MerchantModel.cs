using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models
{
    public class Merchant
    {
    public int Id { get; set; }
    public int AdminId { get; set; }
    public string MerchantName { get; set; }
    public string CreatedAt { get; set; }
    public User Admin { get; set; } 
    public List<Product> Products { get; set;} 
    }
}