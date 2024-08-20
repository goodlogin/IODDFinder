using System.Web;
using CommunityToolkit.Mvvm.ComponentModel;
using IODDFinder.Models;
using IODDFinder.Services;

namespace IODDFinder.ViewModels;

public class ProductsViewModel : ObservableObject, IQueryAttributable
{
    private readonly APIService _apiService;

    private string? _vendor;
    public string? Vendor
    {
        get => _vendor;
        set => SetProperty(ref _vendor, value);
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
        set => SetProperty(ref _selectedContent, value);
    }

    public ProductsViewModel(APIService apiService)
    {
        _apiService = apiService;
    }

    public async Task FetchDriversAsync()
    {
        var drivers = await _apiService.GetDriversAsync(Vendor!);
        Contents = drivers.Content
            .OrderBy(x => x.ProductName).ToList();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Vendor = HttpUtility.UrlDecode(query["vendor"].ToString());
    }
}