using JokeDePapa.Domain.Model;

namespace JokeDePapa.Service.Contracts
{
    public interface IJokeService
    {
        Joke GetRandomJoke();
    }
}
