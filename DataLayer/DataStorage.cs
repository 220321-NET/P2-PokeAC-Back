using System.Linq;

namespace DataLayer;
public class DataStorage : IRepo
{
    private readonly PACDBContext _context;
    public DataStorage(PACDBContext context)
    {
        _context = context;
    }
    public User getUser(User user)
    {
    
    }

    /*
        me taking notes
        this is how you add a user
        pub user add(user)
        _context.User.Add(user);
        _context.SaveChanges();
        return user;
    
        pub List<user> getalluser
        return _context.Users.Select(i => i).ToListAsync();

        

    */
}
