namespace DataLayer;

public interface IRepo
{

    Task<User> getUserAsync(User userToGet); 
    User GetUserByUsername(string usernameToTry);                           // login method


    public User CreateUser(User userToCreate);
    Task<List<Pokemon>> GetAllPokemonAsync();
    // Task UserWon(User winner);
    // Task UserLost(User loser);
    // Task UserTied(User player1, User player2);
    Task MatchResult (User player, string result);
    Task AddToDex(User player, Pokemon pokemon);
    Task<List<Pokemon>> RemoveFromDex(User player, Pokemon pokemon);
    Task RemoveAllFromDex(User player);                             // 
    Task<List<Pokemon>> GetUsersDex(User player);                   // Gets list of Pokemon given player
    Task<List<User>> GetLeaderboardWins();                          // Return users for leaderboard
    Task<List<User>> GetLeaderboardWinRate();                       // Return win rate for leaderboard
    Task DeleteUserSession(User user);                              // unimplemented
    Task<Pokemon> getPokemonInfo(string pokemon);                   // given name, return Pokemon
    Task<Pokemon> getRandomPokemon();
}

//Pokemon CreatePokemon(Pokemon pkmToCreate);

/*
todo list
-user related
add/create user (sign up)
way to check if user already exists (no dupes)
login (sign up)

user won (these three update the counter by 1) all three of these add to the users matches
user lost
user tied (oh i forgot to add this to the model, i guess ignore this and we'll calc it by doing matchs - wins - losses or something )
-pokemon related
pull all pokemon (populate pokedex)
pull information about a specific pokemon? (not really necessary as we can work with the list)

-game related
add user pokemon (this is done by user.id)
pull all user pokemon

clear list? (remove all from this table)

-leaderboard
pulls list of user sorted by wins for now

--tier 1 stretch--

*/