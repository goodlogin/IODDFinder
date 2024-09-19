using IODDFinder.Services;

namespace IODDFinder.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly APIService _apiService;
    private readonly NavigationService _navigationService;

    private string? _searchText;
    public string? SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            OnPropertyChanged(nameof(Vendors));
        }
    }

    public List<string>? _vendors;
    public List<string>? Vendors
    {
        get => _vendors?.Where(x => x.Contains(SearchText?.Trim() ?? "",
            StringComparison.InvariantCultureIgnoreCase)).ToList();
        set => SetProperty(ref _vendors, value);
    }

    private string? _selectedVendor;
    public string? SelectedVendor
    {
        get => null;
        set
        {
            SetProperty(ref _selectedVendor, value);
            OnPropertyChanged(nameof(SelectedVendor)); // to fix selected item on back navigation

            _navigationService.GoToProductsPageAsync(_selectedVendor!);
        }
    }

    public MainViewModel(
        APIService apiService,
        NavigationService navigationService)
    {
        _apiService = apiService;
        _navigationService = navigationService;
    }

    public async Task FetchVendorsAsync()
    {
        var vendorsResponse = await _apiService.GetVendorsAsync();
        if (vendorsResponse.HasError)
        {
            // TODO: show error/message panel(set STATE_ERROR)
            // vendorsResponse.Error
            return;
        }

        Vendors = vendorsResponse.Vendors!
                .OrderBy(x => x).ToList();
    }
}