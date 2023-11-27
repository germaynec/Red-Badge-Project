using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Data.Models;

namespace ECommerceMVC.Models
{
    public class Product
    {
    public int Id { get; set; }
    public string Name { get; set; }
    public int MerchantId { get; set; }
    public int Price { get; set; }
    public string Status { get; set; }
    public string CreatedAt { get; set; }
    public int CategoryId { get; set; }
    public Merchant Merchant { get; set; }
    public Category Category { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    
    }
}