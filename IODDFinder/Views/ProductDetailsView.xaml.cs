using IODDFinder.ViewModels;

namespace IODDFinder.Views;

public partial class ProductDetailsView : ContentPage
{
    private readonly ProductDetailsViewModel _vm;

    public ProductDetailsView(ProductDetailsViewModel productDetailsViewModel)
	{
        InitializeComponent();

        _vm = productDetailsViewModel;
        BindingContext = _vm;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await _vm.FetchVariantProductAsync();
    }
}
