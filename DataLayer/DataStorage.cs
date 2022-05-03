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
    public User CreateUser(User userToCreate)
    {
        _context.Users!.Add(userToCreate);
        _context.SaveChanges();
        return userToCreate;
    }
    /*
    public async Task<User> CreateUser(User userToCreate)
    {
        _context.Users.Add(userToCreate);
        await _context.SaveChangesAsync();
        return userToCreate;

    }
    */
    public async Task<List<Pokemon>> GetAllPokemonAsync()
    {
        return await _context.Pokemon.ToListAsync();
    }

    public async Task<List<User>> GetLeaderboardWinRate()
    {
        return await _context.Users
            .FromSqlRaw("Select * from Users Order By (wins *1.0) /(matches * 1.0) desc")
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
        //someone make sure this is right and when they do delete this comment
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
        //someone make sure this is right and when they do delete this comment
    }

    public async Task RemoveAllFromDex(User player)
    {
        List<Pokedex> tempDex = await _context.Pokedex
            .FromSqlRaw($"Select * from Pokedex where userId = {player.id}")
            .ToListAsync();
        foreach (Pokedex p in tempDex)
        {
            //loop through to find the first one that matches the given player and pokemon id
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
            //loop through to find the firs tone that matches the given player and pokemon id
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

    // Removed in favor of one method
    // public async Task UserLost(User loser)
    // {
    //     _context.Users.Update(loser);
    //     await _context.SaveChangesAsync();
    // }

    // public async Task UserTied(User player1, User player2)
    // {
    //     _context.Users.Update(player1);
    //     _context.Users.Update(player2);
    //     await _context.SaveChangesAsync();
    // }



    // public async Task UserWon(User winner)
    // {
    //     _context.Users.Update(winner);
    //     await _context.SaveChangesAsync();
    // }

    public async Task DeleteUserSession(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<Pokemon> getPokemonInfo(string pokemon)
    {
        return await _context.Pokemon.FirstOrDefaultAsync(poke => poke.name == pokemon);
    }

    public async Task MatchResult(User player, string result)
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
        //throw new NotImplementedException();
    }

    public async Task<Pokemon> getRandomPokemon()
    {
        List<Pokemon> randomList = await _context.Pokemon.ToListAsync();
        var rdm = new Random();
        Pokemon random = randomList[rdm.Next(randomList.Count)];
        return random;
    }

    /*
        me taking notes
        this is how you add a user
        pub user add(user)
        _context.User.Add(user);
        _context.SaveChanges();
        return user;
    
        pub List<user> getalluser
        return _context.Users.ToListAsync();

        p user getuser(int user.id)
        _context.User.FirstOrDefault(user => user.id == id);

        p List<pokemon> searchtype(string type)
        return _context.Pokemon.Where(pokemon => pokemon.Type1.ToLower().Contains(type)).ToListAsync();

        p void updateScore(user)
        _cntext.user.update(user)
        _context.savechanges

        joins
        return _context.Issues.Include("Answers").ToList();

    */
}
