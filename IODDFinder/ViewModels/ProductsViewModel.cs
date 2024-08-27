using System.Web;
using IODDFinder.Models;
using IODDFinder.Services;
using IODDFinder.Views;

namespace IODDFinder.ViewModels;

public class ProductsViewModel : BaseViewModel, IQueryAttributable
{
    private readonly APIService _apiService;
    private readonly NavigationService _navigationService;

    private string? _vendorName;
    public string? VendorName
    {
        get => _vendorName;
        set => SetProperty(ref _vendorName, value);
    }

    private string? _searchText;
    public string? SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            OnPropertyChanged(nameof(Contents));
        }
    }

    public List<Content>? _contents;
    public List<Content>? Contents
    {
        get => _contents?.Where(x => x.ProductName.Contains(SearchText ?? "",
            StringComparison.InvariantCultureIgnoreCase)).ToList();
        set => SetProperty(ref _contents, value);
    }

    private Content? _selectedContent;
    public Content? SelectedContent
    {
        get => null;
        set
        {
            SetProperty(ref _selectedContent, value);
            OnPropertyChanged(nameof(SelectedContent)); // to fix selected item on back navigation

            _navigationService.GoToProductDetailsPageAsync(
                _selectedContent!.ProductName!,
                _selectedContent!.ProductVariantId!);
        }
    }

    public ProductsViewModel(
        APIService apiService,
        NavigationService navigationService)
    {
        _apiService = apiService;
        _navigationService = navigationService;
    }

    public async Task FetchDriversAsync()
    {
        var drivers = await _apiService.GetDriversAsync(VendorName!);
        Contents = drivers.Content
            .OrderBy(x => x.ProductName).ToList();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        VendorName = HttpUtility.UrlDecode(query["vendorName"].ToString());
    }
}