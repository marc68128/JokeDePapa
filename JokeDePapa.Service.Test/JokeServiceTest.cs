using System;
using System.Collections.Generic;
using System.Linq;
using JokeDePapa.Data.Contracts;
using JokeDePapa.Domain.Model;
using JokeDePapa.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JokeDePapa.Service.Test
{
    [TestClass]
    public class JokeServiceTest
    {


        [TestMethod]
        public void TestMethod1()
        {
            Mock<IJokeRepository> jokeRepo = new Mock<IJokeRepository>();
            jokeRepo.Setup(jr => jr.GetAll())
                .Returns(() => new List<Joke>
                {
                    new Joke {Question = "A", Answer = "AA"},
                    new Joke {Question = "B", Answer = "BB"}
                });

            var jokeService = new JokeService(jokeRepo.Object);

            var joke = jokeService.GetRandomJoke();
            
            Assert.IsNotNull(joke);
            Assert.IsTrue(jokeRepo.Object.GetAll().Select(j => j.Question).Contains(joke.Question));
        }
    }
}
