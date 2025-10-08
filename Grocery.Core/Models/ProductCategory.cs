using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public class ProductCategory: Model
    {
        public List<Product> Products { get; set; }

        // Producten die niet meer op voorraad of eeuwig houdbaar zijn maken geen gebruik van de tht-datum
        public ProductCategory(int id, string name, List<Product> products) : base(id, name)
        {
            Products = products;
        }
    }
}
