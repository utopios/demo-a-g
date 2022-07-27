using CompositionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CompositionAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CompositionController : ControllerBase
{
    //Injection de dépendance 
    private HttpClientService _httpClientService;

    public CompositionController(HttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        ProductResponseDTO productResponseDto = await _httpClientService.GetProduct(id);
        List<CommentResponseDTO> commentsResponseDto = await _httpClientService.GetComments(id);
        return Ok(new ProductDTO(productResponseDto, commentsResponseDto));
        //Normalement il faut gérer les exceptions.
    }
}

public record ProductDTO(ProductResponseDTO product, List<CommentResponseDTO> comments);