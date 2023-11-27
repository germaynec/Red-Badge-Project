using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Data.Models;

namespace ECommerceMVC.Models
{
    public class Order
    {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Status { get; set; }
    public string CreatedAt { get; set; }
    public User User { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    }
}