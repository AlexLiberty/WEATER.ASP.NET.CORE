async function getWeather()
{
    const city = document.getElementById('city').value;
    const response = await fetch(`/weather?city=${city}`);
    const weather = await response.json();
    console.log(weather);

    if (weather) 
    {
        document.getElementById('current-weather-content').innerHTML = `
                        <div class="container2">
                        <div class="weather-item">
                        <p>Місто: ${weather.name}</p>
                        <p>Дата: ${new Date(weather.dt * 1000).toLocaleDateString()}</p>
                        <p>Погода: ${weather.weather[0].description}</p>
                        </div>
                        <div class="weather-item">
                        <img src="http://openweathermap.org/img/wn/${weather.weather[0].icon}.png" class="weather-icon">
                        </div>
                        <div class="weather-item">
                        <p>Температура: ${weather.main.temp} °C</p>
                        <p>Мінімальна температура: ${weather.main.temp_min} °C</p>
                        <p>Максимальна температура: ${weather.main.temp_max} °C</p>
                        <p>Швидкість вітру: ${weather.wind.speed} m/s</p>
                        </div>
                        </div>
                    `;
    }
    else
    {
        document.getElementById('current-weather-content').innerHTML = "<p>Weather data not found.</p>";
    }
}