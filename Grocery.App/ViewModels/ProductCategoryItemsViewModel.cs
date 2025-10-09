using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(ProductCategory), nameof(ProductCategory))]
    public partial class ProductCategoryItemsViewModel : BaseViewModel
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly IProductService _productService;
        private string searchText = "";

        public ObservableCollection<Product> ProductCategoryItems { get; set; } = [];
        public ObservableCollection<Product> AvailableProducts { get; set; } = [];

        [ObservableProperty]
        ProductCategory productCategory = new(0, "None", []);
        [ObservableProperty]
        string myMessage;

        public ProductCategoryItemsViewModel(IProductCategoryService productCategoryService, IProductService productService)
        {
            _productCategoryService = productCategoryService;
            _productService = productService;
            Load(productCategory.Id);
        }

        private void Load(int id)
        {
            ProductCategoryItems.Clear();
            ProductCategoryItems = _productCategoryService.GetProducts(id).ToObservableCollection();
            GetAvailableProducts();
        }

        private void GetAvailableProducts()
        {
            AvailableProducts.Clear();
            foreach (Product p in _productService.GetAll())
                if (ProductCategoryItems.Contains(p) && (searchText=="" || p.Name.ToLower().Contains(searchText.ToLower())))
                    AvailableProducts.Add(p);
        }

        partial void OnProductCategoryChanged(ProductCategory value)
        {
            Load(value.Id);
        }

        [RelayCommand]
        public void AddProduct(Product product)
        {
            if (product == null) return;
            _productCategoryService.AddProduct(ProductCategory.Id, product.Id);
            AvailableProducts.Remove(product);
        }

        [RelayCommand]
        public void PerformSearch(string searchText)
        {
            this.searchText = searchText;
            GetAvailableProducts();
        }
    }
}
