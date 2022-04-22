using System.Linq;

namespace DataLayer;
public class DataStorage : IRepo
{
    private readonly PACDBContext _context;
    public DataStorage(PACDBContext context)
    {
        _context = context;
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
