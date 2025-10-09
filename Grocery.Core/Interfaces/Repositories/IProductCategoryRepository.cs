using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        public List<int> GetProductIds(int id);
        public List<ProductCategory> GetCategories();
        void AddProduct(int productId, int categoryId);
    }
}
