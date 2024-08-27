using IODDFinder.Views;

namespace IODDFinder.Services;

public class NavigationService
{
	public Task GoToProductsPageAsync(string vendorName)
	{
        return Shell.Current.GoToAsync(nameof(ProductsView),
            new Dictionary<string, object>
            {
                {  "vendorName", vendorName },
            });
    }

    public Task GoToProductDetailsPageAsync(string productName, int productVariantId)
    {
        return Shell.Current.GoToAsync(nameof(ProductDetailsView),
            new Dictionary<string, object>
            {
                {  "productName", productName },
                {  "productVariantId", productVariantId }
            });
    }

    public Task GoToIODDViewerPageAsync(string productName, int vendorId, int deviceId)
    {
        return Shell.Current.GoToAsync(nameof(IODDViewerView),
            new Dictionary<string, object>
            {
                {  "productName", productName },
                {  "vendorId", vendorId },
                {  "deviceId", deviceId },
            });
    }
}

