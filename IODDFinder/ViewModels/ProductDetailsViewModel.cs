using System.Text;
using System.Web;
using System.Windows.Input;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using IODDFinder.Models;
using IODDFinder.Services;

namespace IODDFinder.ViewModels;

public class ProductDetailsViewModel : BaseViewModel, IQueryAttributable
{
    private readonly APIService _apiService;
    private readonly NavigationService _navigationService;
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

    public ProductDetailsViewModel(
        APIService apiService,
        NavigationService navigationService,
        IFileSaver fileSaver)
    {
        _apiService = apiService;
        _navigationService = navigationService;
        _fileSaver = fileSaver;

        DownloadCommand = new Command(async () => await SaveIODDZipAsync());

        ViewCommand = new Command(() =>
        {
            _navigationService.GoToIODDViewerPageAsync(
                _productVariant!.ProductName!,
                _productVariant!.Vendor!.VendorId,
                _productVariant!.Iodd!.DeviceId);
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
        var zipResponse = await _apiService.GetIoddZipAsync(
            ProductVariant!.Vendor!.VendorId,
            ProductVariant!.Iodd!.Id);

        if (zipResponse.HasError)
        {
            // TODO: show error
            return;
        }

        var fileName = $"{ProductVariant.Iodd.DeviceName!}.zip";
        using var stream = new MemoryStream(zipResponse.ZipByteArray!);
        var fileSaverResult = await _fileSaver.SaveAsync(fileName, stream);
        if (fileSaverResult.IsSuccessful)
        {
            await Toast.Make($"The file '{fileName}' was saved successfully to: {fileSaverResult.FilePath}").Show();
        }
        else
        {
            await Toast.Make($"The file was not saved successfully with error: {fileSaverResult.Exception.Message}").Show();
        }
    }
}

