using Microsoft.AspNetCore.Mvc;
using DataLayer;
using Models;

namespace WebAPI.Controllers;

[Route("[api/controller]")]
[ApiController]
public class PokemonContoller : ControllerBase
{
    private readonly IRepo _dl;

    public PokemonController( IRepo dl)
    {
        _dl = dl;
    }


}
