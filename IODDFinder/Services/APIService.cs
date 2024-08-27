using System.Text.Json;
using IODDFinder.Models;

namespace IODDFinder.Services;

public class APIService
{
    private const string BASE_URL = "https://ioddfinder.io-link.com/api";

    private readonly HttpClient _httpClient;
	private readonly JsonSerializerOptions _serializerOptions;

    public APIService()
	{
		_httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(3) };
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

	public async Task<VendorsResponse> GetVendorsAsync()
	{
        try
        {
            var url = $"{BASE_URL}/drivers/vendors";
            var httpResponseMessage = await _httpClient.GetAsync(url);
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            var vendors = JsonSerializer.Deserialize<List<string>>(json, _serializerOptions);

            return new VendorsResponse()
            {
                Vendors = vendors
            };
        }
        catch (Exception ex)
        {
            return new VendorsResponse
            {
                Error = ex.Message
            };
        }
    }

    public async Task<DriversResponse> GetDriversAsync(string vendorName)
    {
        try
        {
            var url = $"{BASE_URL}/drivers?page=0&size=100000&status=APPROVED&status=UPLOADED&vendorName={vendorName}";
            var httpResponseMessage = await _httpClient.GetAsync(url);
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<DriversResponse>(json, _serializerOptions);

            return response!;
        }
        catch (Exception ex)
        {
            return new DriversResponse
            {
                Error = ex.Message
            };
        }
    }

    public async Task<ProductVariantResponse> GetProductVariantAsync(string productVariantId)
    {
        try
        {
            var url = $"{BASE_URL}/productvariants/{productVariantId}";
            var httpResponseMessage = await _httpClient.GetAsync(url);
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<ProductVariantResponse>(json, _serializerOptions);

            return response!;
        }
        catch (Exception ex)
        {
            return new ProductVariantResponse
            {
                Error = ex.Message
            };
        }
    }

    public async Task<ProductVariantMenuResponse> GetProductVariantMenusAsync(string vendorId, string deviceId)
    {
        try
        {
            var url = $"{BASE_URL}/productvariants/{vendorId}/{deviceId}/viewer?version=1.1";

            var httpResponseMessage = await _httpClient.GetAsync(url);
            var json = await httpResponseMessage.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<ProductVariantMenuResponse>(json, _serializerOptions);

            return response!;
        }
        catch (Exception ex)
        {
            return new ProductVariantMenuResponse
            {
                Error = ex.Message
            };
        }
    }
}