using IODDFinder.ViewModels;

namespace IODDFinder.Views;

public partial class IODDViewerView : ContentPage
{
	private readonly IODDViewerViewModel _vm;

    public IODDViewerView(IODDViewerViewModel ioddViewerViewModel)
	{
		InitializeComponent();
        _vm = ioddViewerViewModel;
		BindingContext = _vm;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await _vm.FetchVariantProductMenuAsync();
    }
}
