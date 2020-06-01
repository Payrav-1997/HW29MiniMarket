using System.Collections.Generic;

namespace HW27_MiniMarket.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public ProductCategory ProductCategory { get; set; }
        
    }
}