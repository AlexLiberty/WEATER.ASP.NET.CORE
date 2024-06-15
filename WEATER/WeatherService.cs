using System.Text.Json;
public class WeatherService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl;

    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["WeatherApi:ApiKey"];
        _baseUrl = configuration["WeatherApi:BaseUrl"];
    }

    public async Task<WeatherResponse> GetCurrentWeatherAsync(string city)
    {
        var response = await _httpClient.GetAsync($"{_baseUrl}weather?q={city}&appid={_apiKey}&units=metric");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<WeatherResponse>(content);
        }
        return null;
    }
}
