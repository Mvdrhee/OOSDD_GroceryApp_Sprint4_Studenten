using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.Models
{
    public class ProductCategory: Model
    {
        public List<int> ProductIds { get; set; }

        // Producten die niet meer op voorraad of eeuwig houdbaar zijn maken geen gebruik van de tht-datum
        public ProductCategory(int id, string name, List<int> productIds) : base(id, name)
        {
            ProductIds = productIds;
        }
    }
}
