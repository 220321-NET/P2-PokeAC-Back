using System.Linq;

namespace DataLayer;
public class DataStorage : IRepo
{
    private readonly PACDBContext _context;
    public DataStorage(PACDBContext context)
    {
        _context = context;
    }

    public async Task AddToDex(User player, Pokemon pokemon)
    {
        Pokedex add = new Pokedex(player.id, pokemon.id);
        _context.Pokedex.Add(add);
        await _context.SaveChangesAsync();

    }
    public Boolean takenUsername(string username)
    {
        return _context.Users.Any(user => user.username == username);
    }
    public User GetUserByUsername(string usernameToTry)
    {
        return _context.Users!.FirstOrDefault(user => user.username == usernameToTry)!;
    }

    public User CreateUser(User userToCreate)
    {
        _context.Users!.Add(userToCreate);
        _context.SaveChanges();
        return userToCreate;
    }

    public async Task<List<Pokemon>> GetAllPokemonAsync()
    {
        return await _context.Pokemon.ToListAsync();
    }

    public async Task<List<User>> GetLeaderboardWinRate()
    {
        return await _context.Users
            .FromSqlRaw("Select * from Users Where matches > 0 Order By (wins *1.0) /(matches * 1.0) desc")
            .ToListAsync();
    }

    public async Task<List<User>> GetLeaderboardWins()
    {
        return await _context.Users
            .FromSqlRaw("Select * from Users Order By wins desc")
            .ToListAsync();
    }
    public async Task<User> getUserAsync(User userToGet)
    {
        return await _context.Users.FirstOrDefaultAsync(user => userToGet.username == user.username && userToGet.password == user.password);
    }

    public async Task<List<Pokemon>> GetUsersDex(User player)
    {
        List<Pokedex> tempDex = await _context.Pokedex
            .FromSqlRaw($"Select * from Pokedex where userId = {player.id}")
            .ToListAsync();
        List<Pokemon> userDex = new List<Pokemon>();
        foreach (Pokedex p in tempDex)
        {
            userDex.Add(await _context.Pokemon.FirstOrDefaultAsync(poke => poke.id == p.pokeID));
        }
        foreach (Pokemon p in userDex)
        {
            Console.WriteLine($"name : {p.name}");
        }
        return userDex;
    }

    public async Task RemoveAllFromDex(User player)
    {
        List<Pokedex> tempDex = await _context.Pokedex
            .FromSqlRaw($"Select * from Pokedex where userId = {player.id}")
            .ToListAsync();
        foreach (Pokedex p in tempDex)
        {
            if (p.userId == player.id)
            {
                _context.Remove(p);
                await _context.SaveChangesAsync();
            }
        }
    }

    public async Task<List<Pokemon>> RemoveFromDex(User player, Pokemon pokemon)
    {
        List<Pokedex> tempDex = await _context.Pokedex
            .FromSqlRaw($"Select * from Pokedex where userId = {player.id}")
            .ToListAsync();
        foreach (Pokedex p in tempDex)
        {
            if (p.userId == player.id && p.pokeID == pokemon.id)
            {
                _context.Remove(p);
                await _context.SaveChangesAsync();
                break;
            }
        }

        tempDex = await _context.Pokedex
            .FromSqlRaw($"Select * from Pokedex where userId = {player.id}")
            .ToListAsync();

        List<Pokemon> userDex = new List<Pokemon>();
        foreach (Pokedex p in tempDex)
        {
            userDex.Add(await _context.Pokemon.FirstOrDefaultAsync(poke => poke.id == p.id));
        }
        return userDex;
    }

    public async Task InsertIntoMatches(User player, int opponentId, string result)
    {
        Match match = new Match(player.id, opponentId, result);
        _context.Matches.Add(match);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteUserSession(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<Pokemon> getPokemonInfo(string pokemon)
    {
        return await _context.Pokemon.FirstOrDefaultAsync(poke => poke.name == pokemon);
    }

    public async Task<User> MatchResult(User player, string result)
    {
        User temp = await _context.Users.FirstOrDefaultAsync(user => player.username == user.username && player.password == user.password);
        temp.matches++;
        switch (result)
        {
            case "won":
                temp.wins++;
                break;
            case "lost":
                temp.losses++;
                break;
            default:
                break;
        }
        _context.Users.Update(temp);
        await _context.SaveChangesAsync();
        return temp;
    }

    public async Task<Pokemon> getRandomPokemon()
    {
        List<Pokemon> randomList = await _context.Pokemon.ToListAsync();
        var rdm = new Random();
        Pokemon random = randomList[rdm.Next(randomList.Count)];
        return random;
    }
}
