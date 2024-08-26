using System.Web;

namespace IODDFinder.ViewModels;

public class IODDViewerViewModel : BaseViewModel
{
    private string? _productVariantId;
    public string? ProductVariantId
    {
        get => _productVariantId;
        set => SetProperty(ref _productVariantId, value);
    }

    private string? _productName;
    public string? ProductName
    {
        get => _productName;
        set => SetProperty(ref _productName, value);
    }

    public IODDViewerViewModel()
	{
	}

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ProductVariantId = query["productVariantId"].ToString();
        ProductName = HttpUtility.UrlDecode(query["productName"].ToString());
    }
}
