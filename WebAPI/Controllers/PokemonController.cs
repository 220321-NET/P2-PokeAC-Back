using Microsoft.AspNetCore.Mvc;
using DataLayer;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PokemonContoller : ControllerBase
{
    private readonly IRepo _dl;
    private readonly ILogger<PokemonController> _logger;

    public PokemonController(ILogger<PokemonController> logger, IRepo dl)
    {
        _logger = logger;
        _dl = dl;
    }

    [HttpGet("GetRandomPokemonFromList")]
    public string GetRandomPokemon()
    {
        return _dl.FindRandomPokemon();
    }
}
