using IODDFinder.Models;
using IODDFinder.ViewModels;

namespace IODDFinder.Views;

public partial class ProductsView : ContentPage
{
    private readonly ProductsViewModel _vm;

    public List<Content>? Contants { get; set; }

    public ProductsView(ProductsViewModel vm)
	{
		InitializeComponent();

        _vm = vm;
        BindingContext = _vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await _vm.FetchDriversAsync();
    }
}
