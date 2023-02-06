using ComicsBackend.Comics.Domain.DTO;
using ComicsBackend.Comics.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComicsBackend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ComicsController : ControllerBase
{
    private readonly IComicsService _comicsService;

    public ComicsController(IComicsService comicsService)
    {
        _comicsService = comicsService;
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetComics()
    {
        var result = await _comicsService.GetComicsRandom();

        if (result is null)
        {
            return BadRequest("Invalid url");
        }

        return Ok(result);
    }
    
    [HttpDelete("[action]")]
    public IActionResult DeleteComics([FromBody] ComicsModel comics)
    {
        var result = _comicsService.DeleteComics(comics);

        if (result is null)
        {
            return BadRequest("Invalid comics");
        }

        return Ok(result);
    }
}