using System;
using System.Collections.Generic;
using JokeDePapa.App.ViewModel;
using JokeDePapa.Data.Contracts;
using JokeDePapa.Domain.Model;
using JokeDePapa.Service.Contracts;
using JokeDePapa.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace JokeDePapa.App.Test
{
    [TestClass]
    public class MainPageViewModelTest
    {
        private MainPageViewModel _viewModel;
        private static Joke _joke;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _joke = new Joke { Id = 1, Question = "AA", Answer = "BB" };
        }

        [TestInitialize]
        public void TestInitialize()
        {
            Mock<IJokeService> jokeService = new Mock<IJokeService>();
            jokeService.Setup(jr => jr.GetRandomJoke(It.IsAny<List<int>>())).Returns(() => _joke);

            _viewModel = new MainPageViewModel(jokeService.Object);
        }

        [TestMethod]
        public void NextJokeCommand_SetJoke()
        {
            _viewModel.NextJokeCommand.Execute(null);

            Assert.AreEqual("AA", _viewModel.Question);
            Assert.AreEqual("BB", _viewModel.Answer);
        }
    }
}
