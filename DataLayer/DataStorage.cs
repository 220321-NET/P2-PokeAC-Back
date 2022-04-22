namespace DataLayer;
using Microsoft.Data.SqlClient;
public class DataStorage : IRepo
{   
    private readonly string _connectionString = "Server=tcp:p0-server.database.windows.net,1433;Initial Catalog=P2DB;Persist Security Info=False;User ID=p0admin;Password=P@ssw0rd!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    // public DataStorage(string _connectionString)
    // {
    //     _connectionString = _connectionString;
    // }
    
    public string FindRandomPokemon()
    {
        Pokemon randomPokemon = new Pokemon();
        Random rnd = new Random();
        int num = rnd.Next(1, 6);

        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Pokemon WHERE PokeID = @num", connection);
        cmd.Parameters.AddWithValue("num", num);

        SqlDataReader dataReader = cmd.ExecuteReader();

        if(dataReader.Read())
        {
            randomPokemon.name = dataReader.GetString(1);
        }

        return randomPokemon.name;
    }

    public User getUser(UnobservedTaskExceptionEventArgs user)
    {
        
    }
}
