using System.Text.Json.Serialization;

using Newtonsoft.Json;

namespace CompositionAPI.Services;

public class HttpClientService
{
    // on peut stocker la base url dans des variables d'environnement, c'est mieux.
    //Adresse de l'api product
    private string _baseURLProduct = "http://localhost:5191/";
    //Adresse de l'api comment
    private string _baseURLComment = "http://localhost:5164/";
    private HttpClient _httpClient;
    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<ProductResponseDTO> GetProduct(int id)
    {
        var response= await _httpClient.GetAsync(_baseURLProduct+ "api/v1/product/"+id);
        //j'utilise package nuget newton soft json pour convertir la réponse en objet json
        if (response.IsSuccessStatusCode)
        {
            ProductResponseDTO product = JsonConvert.DeserializeObject<ProductResponseDTO>(await response.Content.ReadAsStringAsync());
            return product;
        }

        throw new Exception("No product founded");
    }
    
    public async Task<List<CommentResponseDTO>> GetComments(int id)
    {
        var response= await _httpClient.GetAsync(_baseURLComment+ "api/v1/comment/"+id);
        //j'utilise package nuget newton soft json pour convertir la réponse en objet json
        if (response.IsSuccessStatusCode)
        {
            List<CommentResponseDTO> comments = JsonConvert.DeserializeObject<List<CommentResponseDTO>>(await response.Content.ReadAsStringAsync());
            return comments;
        }

        throw new Exception("No comments founded");
    }
}
public  record ProductResponseDTO(int Id, String Title, decimal Price);
public  record  CommentResponseDTO(string Content, int ProductId);