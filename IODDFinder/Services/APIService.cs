using System.Text.Json;
using System.Web;
using IODDFinder.Models;

namespace IODDFinder.Services;

public class APIService
{
    private const string BASE_URL = "https://ioddfinder.io-link.com/api";

    private readonly HttpClient _httpClient;
	private readonly JsonSerializerOptions _serializerOptions;

    public APIService()
	{
		_httpClient = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

	public async Task<VendorsResponse> GetVendorsAsync()
	{
		var json = await _httpClient.GetStringAsync($"{BASE_URL}/drivers/vendors");
        var vendors = JsonSerializer.Deserialize<List<string>>(json, _serializerOptions);

        return new VendorsResponse()
        {
            Vendors = vendors ?? new List<string>()
        };
    }

    public async Task<DriversResponse> GetDriversAsync(string vendorName)
    {
        var url = $"{BASE_URL}/drivers?page=0&size=100000&status=APPROVED&status=UPLOADED&vendorName={vendorName}";
        var json = await _httpClient.GetStringAsync(url);
        var response = JsonSerializer.Deserialize<DriversResponse>(json, _serializerOptions);

        return response!;
    }
}

