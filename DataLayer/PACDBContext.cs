using Microsoft.EntityFrameworkCore;
using Models;

namespace DataLayer;

public class PACDBContext : DbContext
{

    public PACDBContext() : base() { }
    public PACDBContext(DbContextOptions options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Pokemon> Pokemon { get; set; }
}

//dotnet ef migrations add initial -c PACDBContext -- startup-project ../WebAPI
//dotnet ef database update --startup-project ../WebAPI