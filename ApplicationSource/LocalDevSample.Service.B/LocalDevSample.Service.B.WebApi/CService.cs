namespace LocalDevSample.Service.B.WebApi;

public class CService : ICService
{
    private readonly HttpClient _httpClient;

    public CService(HttpClient httpClient, ICServiceOptions cServiceOptions)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri(cServiceOptions.UriEndpoint);
    }

    public async Task<int> GetTemperature() =>
        await _httpClient.GetFromJsonAsync<int>("/temperature");
}


