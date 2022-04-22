namespace DataLayer;

public interface IRepo
{
    public Pokemon FindRandomPokemonById(Pokemon cpuCard);

    public User getUser(User user);
}