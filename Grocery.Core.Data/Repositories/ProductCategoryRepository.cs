using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository: IProductCategoryRepository
    {
        private readonly List<ProductCategory> categories;
        public ProductCategoryRepository()
        {
            categories = [
                new ProductCategory(1, "Zuivel", [1, 2]),
                new ProductCategory(2, "Ontbijt", [2, 3, 4])
                ];
        }
        public List<ProductCategory> GetCategories()
        {
            return categories;
        }
        public List<int> GetProductIds(int id)
        {
            return categories.First(c => c.Id == id).ProductIds;
        }
        public void AddProduct(int productId, int categoryId)
        {
            ProductCategory? category = categories.FirstOrDefault(c => c.Id == categoryId);
            if (category == null) { return; }
            if (!category.ProductIds.Contains(productId))
            {
                category.ProductIds.Add(productId);
            }
        }
    }
}
