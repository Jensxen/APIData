using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class ApiDataService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;
    private readonly string _apiKey;

    public ApiDataService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _baseUrl = configuration["ApiSettings:BaseUrl"]!;
        _apiKey = configuration["ApiSettings:ApiKey"]!;
    }

    public async Task<string> GetRawJsonAsync(int? id = null)
    {
        string url = $"{_baseUrl}?code={_apiKey}";
        if (id.HasValue)
        {
            url += $"&id={id}";
        }
        return await _httpClient.GetStringAsync(url);
    }

    public async Task<ApiItem?> GetItemAsync(int? id = null)
    {
        string rawJson = await GetRawJsonAsync(id);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = null // Keep original property names
        };

        return JsonSerializer.Deserialize<ApiItem>(rawJson, options);
    }
}

