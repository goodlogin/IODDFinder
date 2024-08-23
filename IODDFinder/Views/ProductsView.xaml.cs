using IODDFinder.ViewModels;

namespace IODDFinder.Views;

public partial class ProductsView : ContentPage
{
    private readonly ProductsViewModel _vm;

    public ProductsView(ProductsViewModel productsViewModel)
	{
		InitializeComponent();

        _vm = productsViewModel;
        BindingContext = _vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await _vm.FetchDriversAsync();
    }
}
