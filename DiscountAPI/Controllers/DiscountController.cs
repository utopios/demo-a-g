using Microsoft.AspNetCore.Mvc;

namespace DiscountAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DiscountController : ControllerBase
{
    private List<DiscountResponseDTO> fakeData = new List<DiscountResponseDTO>()
    {
        new DiscountResponseDTO("1234", 100),
        new DiscountResponseDTO("4321", 500),
    };
    
    [HttpGet("{code}")]
    public IActionResult Get(string code)
    {
        DiscountResponseDTO response = fakeData.FirstOrDefault(e => e.CodeReduction == code);
        if (response != null)
        {
            return Ok(response);
        }
        return NotFound();
    }
}
//Pour émuler les models, je crée juste des objets de transfert de données avec des faux données
//Dans le cadre ou les DTOs sont utilisé par plusieurs api, on peut les mettre dans une dll(bibliothèque de classe)
//Qu'on ajoute dans chaque projet.
public  record DiscountResponseDTO(string CodeReduction, decimal Value);