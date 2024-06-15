public class WeatherResponse
{
    public string name { get; set; }
    public Main main { get; set; }
    public Wind wind { get; set; }
    public Weather[] weather { get; set; }
    public long dt { get; set; }
}

