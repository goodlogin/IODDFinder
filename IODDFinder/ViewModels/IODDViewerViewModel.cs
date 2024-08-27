using System.Web;
using IODDFinder.Models;
using IODDFinder.Services;

namespace IODDFinder.ViewModels;

public class IODDViewerViewModel : BaseViewModel, IQueryAttributable
{
    private string? _vendorId;
    public string? VendorId
    {
        get => _vendorId;
        set => SetProperty(ref _vendorId, value);
    }

    private string? deviceId;
    public string? DeviceId
    {
        get => deviceId;
        set => SetProperty(ref deviceId, value);
    }

    private string? _productName;
    public string? ProductName
    {
        get => _productName;
        set => SetProperty(ref _productName, value);
    }

    private List<Menu>? _menus;
    public List<Menu>? Menus
    {
        get => _menus;
        set => SetProperty(ref _menus, value);
    }

    private readonly APIService _apiService;

    public IODDViewerViewModel(APIService apiService)
	{
        _apiService = apiService;
	}

    public async Task FetchVariantProductMenuAsync()
    {
        var response = await _apiService.GetProductVariantMenusAsync(_vendorId!, deviceId!);
        Menus = response.Menus!;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        VendorId = query["vendorId"].ToString();
        DeviceId = query["deviceId"].ToString();
        ProductName = HttpUtility.UrlDecode(query["productName"].ToString());
    }
}
