using System.Web;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using IODDFinder.Models;
using IODDFinder.Services;

namespace IODDFinder.ViewModels;

public class ProductDetailsViewModel : ObservableObject, IQueryAttributable
{
    private readonly APIService _apiService;

    public ICommand DownloadCommand { get; set; }

    private string? _productVariantId;
    public string? ProductVariantId
    {
        get => _productVariantId;
        set
        {
            SetProperty(ref _productVariantId, value);
            OnPropertyChanged(nameof(VendorLogo));
            OnPropertyChanged(nameof(DeviceImage));
        }
    }

    private string? _productName;
    public string? ProductName
    {
        get => _productName;
        set => SetProperty(ref _productName, value);
    }

    private ProductVariantResponse? _productVariant;
    public ProductVariantResponse? ProductVariant
    {
        get => _productVariant;
        set => SetProperty(ref _productVariant, value);
    }

    public string? VendorLogo => $"https://ioddfinder.io-link.com/api/productvariants/{_productVariantId}/files/vendorLogo";
    public string? DeviceImage => $"https://ioddfinder.io-link.com/api/productvariants/{_productVariantId}/files/symbol";

    public ProductDetailsViewModel(APIService apiService)
    {
        _apiService = apiService;

        DownloadCommand = new Command(() =>
        {
            Launcher.OpenAsync($"https://ioddfinder.io-link.com/api/vendors/{ProductVariant!.Iodd!.Vendor!.VendorId}/iodds/{ProductVariant!.Iodd!.Id}/files/zip/rated");
        });
    }

    public async Task FetchVariantProductAsync()
    {
        ProductVariant = await _apiService.GetProductVariantAsync(_productVariantId!);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ProductVariantId = query["productVariantId"].ToString();
        ProductName = HttpUtility.UrlDecode(query["productName"].ToString());
    }
}

