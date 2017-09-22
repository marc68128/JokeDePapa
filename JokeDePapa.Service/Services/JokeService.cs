using System;
using System.Collections.Generic;
using System.Linq;
using JokeDePapa.Data.Contracts;
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

        public Joke GetRandomJoke(List<int> excludedJokesIds = null)
        {
            var all = _jokeRepo.GetAll().ToList();

            if (excludedJokesIds != null)
                all = all.Where(j => !excludedJokesIds.Contains(j.Id)).ToList();

            if (all.Count == 0)
                return null;

            return all.ElementAt(new Random().Next(0, all.Count - 1));
        }
    }
}