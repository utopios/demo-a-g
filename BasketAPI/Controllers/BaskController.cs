using BasketAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasketAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BaskController : ControllerBase
{

    private List<ProductDTO> fakeProducts = new List<ProductDTO>()
    {
        new ProductDTO(1, 100),
        new ProductDTO(2, 4000),
        new ProductDTO(3, 400)
    };
    
    //Injection de dépendance 
    private HttpClientService _httpClientService;

    public BaskController(HttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    [HttpPost]
    public async Task<IActionResult> Post(BasketRequestDTO basketRequestDto)
    {
        decimal total = 0;
        //Dans une architectue microservice, cette partie se fait également par une autre api
        foreach (int i in basketRequestDto.ProductsId)
        {
            ProductDTO p = fakeProducts.Find(p => p.Id == i);
            if (p != null)
            {
                total += p.Price;
            }
        }
        //Il faut utiliser un try catch cars si pas de discount il y aura une exception.
        DiscountResponseDTO discount = await _httpClientService.GetDiscount(basketRequestDto.Code);
        total -= discount.Value;
        Random r = new Random(100000);
        int uid = r.Next();
        return Ok(new BasketResponseDTO(uid, total));
    } 
}

//La création des différents DTO
public record DiscountResponseDTO(string CodeReduction, decimal Value); 
public record ProductDTO(int Id, decimal Price);
public record BasketRequestDTO(int[] ProductsId, string Code);
public  record BasketResponseDTO(int Id, decimal Total);