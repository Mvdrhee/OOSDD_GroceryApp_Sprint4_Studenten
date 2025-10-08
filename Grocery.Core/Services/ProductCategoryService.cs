using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class ProductCategoryService: IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IProductRepository _productRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IProductRepository productRepository)
        {
            _productCategoryRepository = productCategoryRepository;
            _productRepository = productRepository;
        }
        public List<ProductCategory> GetProductCategories()
        {
            return _productCategoryRepository.GetCategories();
        }
        public List<Product> GetProducts(int id)
        {
            List<Product> products = [];
            foreach (int productId in _productCategoryRepository.GetProductIds(id))
            {
                Product? product = _productRepository.Get(productId);
                if (product != null) { products.Add(product); }
            }
            return products;
        }
    }
}
