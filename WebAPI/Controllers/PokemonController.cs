using Microsoft.AspNetCore.Mvc;
using DataLayer;
using Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("FindUser/{user}")]
        public async Task<User> GetUserAsync([FromQuery] User user)
        {
            return await _dl.getUserAsync(user);
        }

        [HttpGet("GetLeaderboard")]
        public async Task<List<User>> GetLeaderboardWins()
        {
            return await _dl.GetLeaderboardWins();
        }

        [HttpGet("GetLeaderboardWinRate")]
        public async Task<List<User>> GetLeaderboardWinRate()
        {
            return await _dl.GetLeaderboardWinRate();
        }

        [HttpPut("Winner/{winner}")]
        public async Task UserWon(User winner)
        {
            await _dl.UserWon(winner);
        }

        // [HttpDelete("DeleteUser/{user}")]
        // public async Task DeleteUserSession(User user)
        // {
        //     await _dl.DeleteUserSession(user);
        // }


        [HttpPut("Loser/{loser}")]
        public async Task UserLost(User loser)
        {
            await _dl.UserLost(loser);
        }
        // not sure if we can do this
        [HttpPut("Tied/{players}")]
        public async Task UserTied(List<User> players)
        {
            User p1 = players[0];
            User p2 = players[1];
            await _dl.UserTied(p1, p2);
        }
        [HttpPut("RemoveFromDex/{info}")]
        public async Task<List<Pokemon>> RemoveFromDex(Tuple<User, Pokemon> info)
        {
            User Player = info.Item1;
            Pokemon pokemon = info.Item2;
            return await _dl.RemoveFromDex(Player, pokemon);
        }
        [HttpDelete("RemoveAllFromDex/{username}")]
        public async Task RemoveAllFromDex(User player)
        {
            await _dl.RemoveAllFromDex(player);
        }
        [HttpGet("GetAllPokemon")]
        public async Task<List<Pokemon>> GetAllPokemon()
        {
            return await _dl.GetAllPokemonAsync();
        }

        [HttpGet("GetUsersDex/{username}")]
        public async Task<List<Pokemon>> GetUsersDex(User player)
        {
            return await _dl.GetUsersDex(player);
        }

        [HttpPost("AddToDex/{username}")]
        public async Task AddToDex(Tuple<User, Pokemon> info)
        {
            User Player = info.Item1;
            Pokemon pokemon = info.Item2;
            await _dl.AddToDex(Player, pokemon);
        }
        [HttpGet("getPokemonInfo/{pokemon}")]
        public async Task<Pokemon> getPokemonInfo(string pokemon)
        {
            return await _dl.getPokemonInfo(pokemon);
        }

    }
}