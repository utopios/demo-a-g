using api1.Services;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private HttpClientService _httpClientService;
    public WeatherForecastController( HttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }
    
    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<List<WeatherForecast>> Get()
    {
        return await _httpClientService.GetWeatherForecastsFromAPI2();
    }
}