using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
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
        [HttpGet("UsernameTaken/{username}")]
        public Boolean takenUsername(string username)
        {
            return _dl.takenUsername(username);
        }
        [HttpGet("GetUser/{usernameToTry}")]
        public User GetUserByUsername(string usernameToTry)
        {
            return _dl.GetUserByUsername(usernameToTry);

        }
        [HttpPost("createUser")]
        public void Post(User user)
        {
            _dl.CreateUser(user);
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
        [HttpPut("Match/{result}")]
        public async Task<User> MatchResult(User user, string result)
        {
            return await _dl.MatchResult(user, result);
        }

        [HttpPost("Matches/{opponentId}/{result}")]
        public async Task InsertIntoMatches(User player, int opponentId, string result)
        {
            await _dl.InsertIntoMatches(player, opponentId, result);
        }

        [HttpPut("RemoveFromDex/{info}")]
        public async Task<List<Pokemon>> RemoveFromDex(Tuple<User, Pokemon> info)
        {
            User Player = info.Item1;
            Pokemon pokemon = info.Item2;
            return await _dl.RemoveFromDex(Player, pokemon);
        }
        [HttpDelete("RemoveAllFromDex/{player}")]
        public async Task RemoveAllFromDex(User player)
        {
            await _dl.RemoveAllFromDex(player);
        }

        [HttpGet("GetAllPokemon")]
        public async Task<List<Pokemon>> GetAllPokemon()
        {
            return await _dl.GetAllPokemonAsync();
        }

        [HttpGet("GetUsersDex/{player}")]
        public async Task<List<Pokemon>> GetUsersDex([FromQuery] User player)
        {
            return await _dl.GetUsersDex(player);
        }

        [HttpPost("AddToDex/{info}")]
        public async Task AddToDex(Tuple<User, Pokemon> info)
        {
            User Player = info.Item1;
            Pokemon pokemon = info.Item2;
            await _dl.AddToDex(Player, pokemon);
        }
        [HttpGet("GetPokemonInfo/{pokemon}")]
        public async Task<Pokemon> getPokemonInfo(string pokemon)
        {
            return await _dl.getPokemonInfo(pokemon);
        }
        [HttpGet("GetRandomPokemon")]
        public async Task<Pokemon> getRandomPokemon()
        {
            return await _dl.getRandomPokemon();
        }

    }
}