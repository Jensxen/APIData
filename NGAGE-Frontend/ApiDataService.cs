using System.Text.Json;

public class ApiDataService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl = "https://ngage-praktikant.azurewebsites.net/api/HttpTrigger?code=uqiuCP7a-6_PNSN0ojjtk16VJUSrDe4T4IDEFBfbpHCbAzFuJcuflA==";

    public ApiDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetRawJsonAsync(int? id = null)
    {
        string url = _baseUrl;
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
