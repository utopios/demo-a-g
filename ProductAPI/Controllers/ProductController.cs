using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ProductAPI.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
[EnableCors("all")]
public class ProductController : ControllerBase
{
    private List<ProductResponseDTO> fakeProducts = new List<ProductResponseDTO>()
    {
        new ProductResponseDTO(1, "produt 1", 1000),
        new ProductResponseDTO(2, "product 2", 2000)
    };

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        ProductResponseDTO productResponseDto = fakeProducts.Find(p => p.Id == id);
        if (productResponseDto != null)
            return Ok(productResponseDto);
        else
        {
            return NotFound();
        }
    }
}

public  record ProductResponseDTO(int Id, String Title, decimal Price);