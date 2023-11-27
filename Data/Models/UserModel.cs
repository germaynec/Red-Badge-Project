using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models

{
    public class User
    {
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public string DateOfBirth { get; set; }
    public string CreatedAt { get; set; }
    public List<Order> Orders { get; set; }
    public List<Merchant> AdministratedMerchants { get; set; }
    }
}