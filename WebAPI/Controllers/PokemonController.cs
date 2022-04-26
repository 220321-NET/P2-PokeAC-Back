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

        [HttpPut("{id:int}")]
        public void UserWon(User winner)
        {
            // eventually make this async?
            // here to update the winner globally in the db
            _dl.UserWon(winner);
        }

        [HttpPut("{id:int}")]
        public void UserLost(User loser)
        {
            _dl.UserLost(loser);
        }

        [HttpPut("{id: int}")]
        public void UserTied(User p1, User p2)
        {
            _dl.UserTied(p1, p2);
        }
    }
}