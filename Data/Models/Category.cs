using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceMVC.Models;


namespace ECommerceMVC.Data.Models
{
    public class Category
    {
    public int Id { get; set; }
    public string CatName { get; set; }
    public int ParentId { get; set; }
    public List<Product> Products { get; set; }
    public List<Category> Subcategories { get; set; } 
    public Category ParentCategory { get; set; }
    }
}