using Microsoft.AspNetCore.Mvc;
using DataLayer;
using Models;

namespace WebAPI.Controllers
{
    [Route("[api/controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IRepo _dl;

        public PokemonController(IRepo dl)
        {
            _dl = dl;
        }

        [HttpPost("CreateUser/{userToCreate}")]
        public ActionResult<User> Post([FromBody] User userToCreate)
        {
            return Created("api/Users", _dl.CreateUser(userToCreate));
        }

        [HttpGet("FindUser/{username}")]
        public async Task<ActionResult<User>> getUserAsync(User user)
        {
            return await _dl.getUserAsync(user);
        }



    }
}