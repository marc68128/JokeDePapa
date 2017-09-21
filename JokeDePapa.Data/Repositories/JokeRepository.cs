using System.Collections.Generic;
using System.Linq;
using JokeDePapa.Data.Contracts;
using JokeDePapa.Data.Repositories;
using JokeDePapa.Data.Utils;
using JokeDePapa.Domain.Model;
using SQLite;
using Xamarin.Forms;


[assembly: Dependency(typeof(JokeRepository))]
namespace JokeDePapa.Data.Repositories
{
    public class JokeRepository : IJokeRepository
    {
        static object locker = new object();
        readonly SQLiteConnection _database;

        public JokeRepository()
        {
            _database = DependencyService.Get<ISQLite>().GetConnection();
            _database.CreateTable<Joke>();
            SeedDatabaseIfNeeded(); 
        }

        public IEnumerable<Joke> GetAll()
        {
            lock (locker)
            {
                return (from i in _database.Table<Joke>() select i).ToList();
            }
        }
        public int Create(Joke joke)
        {
            lock (locker)
            {
                if (joke.Id != 0)
                {
                    _database.Update(joke);
                    return joke.Id;
                }
                return _database.Insert(joke);
            }
        }
        public void RemoveAll()
        {
            lock (locker)
            {
                _database.DeleteAll<Joke>();
            }
        }


        private void SeedDatabaseIfNeeded()
        {
            if (GetAll().Count() < Seed.Jokes.Count)
            {
                RemoveAll();
                foreach (var joke in Seed.Jokes)
                    Create(joke);      
            }
        }
    }
}
