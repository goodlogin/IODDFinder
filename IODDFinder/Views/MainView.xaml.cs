using IODDFinder.ViewModels;

namespace IODDFinder.Views;

public partial class MainView : ContentPage
{
	private readonly MainViewModel _vm;

	public MainView(MainViewModel mainViewModel)
	{
		InitializeComponent();

        _vm = mainViewModel;
        BindingContext = _vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

		await _vm.FetchVendorsAsync();
    }
}


