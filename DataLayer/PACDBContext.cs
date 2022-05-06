using Microsoft.EntityFrameworkCore;
using Models;

namespace DataLayer;

public class PACDBContext : DbContext
{

    public PACDBContext() : base() { }
    public PACDBContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Pokemon> Pokemon { get; set; }
    public DbSet<Pokedex> Pokedex{ get; set; }
    public DbSet<Match> Matches {get; set;}
}


//dotnet ef migrations add matchupdate -c PACDBContext --startup-project ../WebAPI
//dotnet ef database update --startup-project ../WebAPI