using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace api1.Services;

public class HttpClientService
{
    // on peut stocker la base url dans des variables d'environnement, c'est mieux.
    //Adresse de l'api 2
    private string _baseURL = "http://localhost:5230/";

    private HttpClient _httpClient;
    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<WeatherForecast>> GetWeatherForecastsFromAPI2()
    {
        var response= await _httpClient.GetAsync(_baseURL+ "api/WeatherForecast");
        //j'utilise package nuget newton soft json pour convertir la réponse en objet json
        List<WeatherForecast> liste = JsonConvert.DeserializeObject<List<WeatherForecast>>(await response.Content.ReadAsStringAsync());
        return liste;
    }
}