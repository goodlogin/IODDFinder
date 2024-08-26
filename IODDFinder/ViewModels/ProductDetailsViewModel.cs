using System.Text;
using System.Web;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using IODDFinder.Models;
using IODDFinder.Services;
using IODDFinder.Views;

namespace IODDFinder.ViewModels;

public class ProductDetailsViewModel : BaseViewModel, IQueryAttributable
{
    private readonly APIService _apiService;
    private readonly IFileSaver _fileSaver;

    public ICommand DownloadCommand { get; set; }
    public ICommand ViewCommand { get; set; }

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

    public ProductDetailsViewModel(APIService apiService, IFileSaver fileSaver)
    {
        _apiService = apiService;
        _fileSaver = fileSaver;

        DownloadCommand = new Command(async () => await SaveIODDZipAsync());

        ViewCommand = new Command(() =>
        {
            Shell.Current.GoToAsync($"{nameof(IODDViewerView)}" +
                $"?productName={_productVariant!.ProductName}" +
                $"&productVariantId={_productVariant!.Id}");
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

    private async Task SaveIODDZipAsync()
    {
        var url = $"https://ioddfinder.io-link.com/api/vendors/{ProductVariant!.Iodd!.Vendor!.VendorId}/iodds/{ProductVariant!.Iodd!.Id}/files/zip/rated";

        using var stream = new MemoryStream(Encoding.Default.GetBytes("Hello from the Community Toolkit!"));
        var fileSaverResult = await _fileSaver.SaveAsync("test.txt", stream);
        if (fileSaverResult.IsSuccessful)
        {
            await Toast.Make($"The file was saved successfully to location: {fileSaverResult.FilePath}").Show();
        }
        else
        {
            await Toast.Make($"The file was not saved successfully with error: {fileSaverResult.Exception.Message}").Show();
        }
    }
}

