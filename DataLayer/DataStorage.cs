using System.Linq;

namespace DataLayer;
public class DataStorage : IRepo
{
    private readonly PACDBContext _context;
    public DataStorage(PACDBContext context)
    {
        _context = context;
    }

    public Task AddToDex(User player, Pokemon pokemon)
    {
        //adds a pokemon to the user's available pool, needs a proper query
        throw new NotImplementedException();
    }

    public User CreateUser(User userToCreate)
    {
        _context.Users.Add(userToCreate);
        _context.SaveChanges();
        return userToCreate;
        //throw new NotImplementedException();
    }

    public async Task<List<Pokemon>> GetAllPokemonAsync()
    {
        return await _context.Pokemon.ToListAsync();
        //throw new NotImplementedException();
    }

    public Task<List<User>> GetLeaderboardWinRate()
    {
        //needs a proper query, grab players sorted by wins/matches
        throw new NotImplementedException();
    }

    public Task<List<User>> GetLeaderboardWins()
    {
        //needs a proper query? grab users sorted by wins
        throw new NotImplementedException();
    }

    public async Task<User> getUserAsync(User userToGet)
    {
        return await _context.Users.FirstOrDefaultAsync(user => userToGet.id == user.id);
        //someone make sure this is right and when they do delete this comment
        throw new NotImplementedException();
    }

    public Task<List<Pokemon>> GetUsersDex(User player)
    {
        throw new NotImplementedException();
    }

    public void UserLost(User loser)
    {
        _context.Users.Update(loser);
        _context.SaveChanges();
        //throw new NotImplementedException();
    }

    public void UserTied(User player1, User player2)
    {
        _context.Users.Update(player1);
        _context.Users.Update(player2);
        _context.SaveChanges();
        //throw new NotImplementedException();
    }

    public void UserWon(User winner)
    {
        _context.Users.Update(winner);
        _context.SaveChanges();
        //throw new NotImplementedException();
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
