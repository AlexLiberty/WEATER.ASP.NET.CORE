
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<WeatherService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/weather", async (HttpContext context, WeatherService weatherService) =>
{
    var city = context.Request.Query["city"].ToString();
    var weather = await weatherService.GetCurrentWeatherAsync(city);
    if (weather == null)
    {
        context.Response.StatusCode = StatusCodes.Status404NotFound;
        await context.Response.WriteAsync("Weather data not found.");
        return;
    }
    await context.Response.WriteAsJsonAsync(weather);
});

app.Run();