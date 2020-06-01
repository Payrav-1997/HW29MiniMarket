using System.Collections.Generic;

namespace HW27_MiniMarket.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}