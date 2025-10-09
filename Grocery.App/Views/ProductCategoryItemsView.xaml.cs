using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class ProductCategoryItemsView : ContentPage
{
	public ProductCategoryItemsView(ProductCategoryItemsViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}