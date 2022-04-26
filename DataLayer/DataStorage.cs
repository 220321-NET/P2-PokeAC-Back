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
    public async Task<User> CreateUser(User userToCreate)
    {
        _context.Users.Add(userToCreate);
        await _context.SaveChangesAsync();
        return userToCreate;

    }

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
        return await _context.Users.FirstOrDefaultAsync(user => userToGet.id == user.id);
        //someone make sure this is right and when they do delete this comment
    }

    public async Task<List<Pokemon>> GetUsersDex(User player)
    {
        List<Pokedex> tempDex = await _context.Pokedex
            .FromSqlRaw($"Select * from Pokedex where userId = {player.id}")
            .ToListAsync();
        List<Pokemon> userDex = new List<Pokemon>();
        foreach (Pokedex p in tempDex){
            userDex.Add(await _context.Pokemon.FirstOrDefaultAsync(poke => poke.id == p.id));
        }
        return userDex;
        //someone make sure this is right and when they do delete this comment
    }

    public void UserLost(User loser)
    {
        _context.Users.Update(loser);
        _context.SaveChanges();
    }

    public void UserTied(User player1, User player2)
    {
        _context.Users.Update(player1);
        _context.Users.Update(player2);
        _context.SaveChanges();
    }

    public void UserWon(User winner)
    {
        _context.Users.Update(winner);
        _context.SaveChanges();        
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
