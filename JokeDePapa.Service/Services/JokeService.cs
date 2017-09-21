using System;
using System.Linq;
using JokeDePapa.Data.Contracts;
using JokeDePapa.Data.Repositories;
using JokeDePapa.Domain.Model;
using JokeDePapa.Service.Contracts;
using JokeDePapa.Service.Services;
using Xamarin.Forms;


[assembly: Dependency(typeof(JokeService))]
namespace JokeDePapa.Service.Services
{
    public class JokeService : IJokeService
    {
        private readonly IJokeRepository _jokeRepo;

        public JokeService()
        {
            _jokeRepo = DependencyService.Get<IJokeRepository>();
        }
        public JokeService(IJokeRepository jokeRepo)
        {
            _jokeRepo = jokeRepo ?? DependencyService.Get<IJokeRepository>(); 

        }

        public Joke GetRandomJoke()
        {
            var all = _jokeRepo.GetAll().ToList();
            return all.ElementAt(new Random().Next(0, all.Count - 1));
        }
    }
}
