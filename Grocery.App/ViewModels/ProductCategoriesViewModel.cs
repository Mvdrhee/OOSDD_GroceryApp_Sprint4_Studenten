using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;

namespace Grocery.App.ViewModels
{
    public partial class ProductCategoriesViewModel : BaseViewModel
    {
        public ObservableCollection<ProductCategory> ProductCategories { get; set; }
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoriesViewModel(IProductCategoryService productCategoryService) 
        {
            Title = "ProductCategorieën";
            _productCategoryService = productCategoryService;
            ProductCategories = new(_productCategoryService.GetProductCategories());
        }

        [RelayCommand]
        public async Task SelectProductCategory(ProductCategory productCategory)
        {
            Dictionary<string, object> paramater = new() { { nameof(ProductCategory), productCategory } };
            await Shell.Current.GoToAsync($"{nameof(Views.ProductCategoryItemsView)}?Titel={productCategory.Name}", true, paramater);
        }
    }
}
