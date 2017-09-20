using System;
using System.Collections.Generic;
using System.Linq;
using JokeDePapa.Data.Contracts;
using JokeDePapa.Data.Repositories;
using JokeDePapa.Domain.Model;
using SQLite;
using Xamarin.Forms;


[assembly: Dependency(typeof(JokeRepository))]
namespace JokeDePapa.Data.Repositories
{
    public class JokeRepository : IJokeRepository
    {
        static object locker = new object();

        SQLiteConnection database;

        public JokeRepository()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            // create the tables
            database.CreateTable<Joke>();
        }

        public IEnumerable<Joke> GetAll()
        {
            lock (locker)
            {
                return (from i in database.Table<Joke>() select i).ToList();
            }
        }

        public int Create(Joke joke)
        {
            lock (locker)
            {
                if (joke.Id != 0)
                {
                    database.Update(joke);
                    return joke.Id;
                }
                return database.Insert(joke);
            }
        }
    }
}
