using System.Text.Json.Serialization;
using BasketAPI.Controllers;
using Newtonsoft.Json;

namespace BasketAPI.Services;

public class HttpClientService
{
    // on peut stocker la base url dans des variables d'environnement, c'est mieux.
    //Adresse de l'api discount
    private string _baseURL = "http://localhost:5265/";

    private HttpClient _httpClient;
    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<DiscountResponseDTO> GetDiscount(string code)
    {
        var response= await _httpClient.GetAsync(_baseURL+ "api/v1/discount/"+code);
        //j'utilise package nuget newton soft json pour convertir la réponse en objet json
        if (response.IsSuccessStatusCode)
        {
            DiscountResponseDTO discount = JsonConvert.DeserializeObject<DiscountResponseDTO>(await response.Content.ReadAsStringAsync());
            return discount;
        }

        throw new Exception("No discount founded");
    }
}