using IODDFinder.ViewModels;

namespace IODDFinder.Views;

public partial class MainView : ContentPage
{
	private readonly MainViewModel _vm;

	public List<string>? Vendors { get; set; }

	public MainView(MainViewModel vm)
	{
		InitializeComponent();

        _vm = vm;
        BindingContext = _vm;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();

		await _vm.FetchVendorsAsync();
    }
}


