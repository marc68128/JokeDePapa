using System;
using System.Collections.Generic;
using System.Linq;
using JokeDePapa.Data.Contracts;
using JokeDePapa.Domain.Model;
using JokeDePapa.Service.Contracts;
using JokeDePapa.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JokeDePapa.Service.Test
{
    [TestClass]
    public class JokeServiceTest
    {
        private IJokeService _jokeService;
        private static List<Joke> _jokes;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _jokes = new List<Joke>
            {
                new Joke { Id = 1, Question = "A", Answer = "AA" },
                new Joke { Id = 2, Question = "B", Answer = "BB" }
            };
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Mock<IJokeRepository> jokeRepo = new Mock<IJokeRepository>();
            jokeRepo.Setup(jr => jr.GetAll()).Returns(() => _jokes);

            _jokeService = new JokeService(jokeRepo.Object);
        }

        [TestMethod]
        public void GetRandom_WithoutExcluded_ReturnJoke()
        {
            var joke = _jokeService.GetRandomJoke();

            Assert.IsNotNull(joke);
            Assert.IsTrue(_jokes.Contains(joke));
        }

        [TestMethod]
        public void GetRandom_WithoutFirstExcluded_ReturnSecond()
        {
            var joke = _jokeService.GetRandomJoke(new List<int> { 1 });

            Assert.IsNotNull(joke);
            Assert.AreEqual(2, joke.Id);
        }

        [TestMethod]
        public void GetRandom_AllExcluded_ReturnNull()
        {
            var joke = _jokeService.GetRandomJoke(_jokes.Select(j => j.Id).ToList());
            Assert.IsNull(joke);
        }
    }
}
