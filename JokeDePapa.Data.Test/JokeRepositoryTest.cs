using System;
using JokeDePapa.Data.Contracts;
using JokeDePapa.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JokeDePapa.Data.Test
{
    [TestClass]
    public class JokeRepositoryTest
    {
        private IJokeRepository _jokeRepository; 

        [TestInitialize]
        public void Init()
        {

            _jokeRepository = new JokeRepository();
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
