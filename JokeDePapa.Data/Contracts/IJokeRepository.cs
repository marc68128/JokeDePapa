using System.Collections.Generic;
using JokeDePapa.Domain.Model;

namespace JokeDePapa.Data.Contracts
{
    public interface IJokeRepository
    {
        IEnumerable<Joke> GetAll();
        int Create(Joke joke); 
    }
}