using System;
using JokeDePapa.Data.Contracts;
using JokeDePapa.Data.Repositories;
using JokeDePapa.Domain.Model;
using Xamarin.Forms;
using JokeDePapa.Service.Contracts;

namespace JokeDePapa.App
{
    public partial class MainPage : ContentPage
    {
        private readonly IJokeService _jokeService;
        public MainPage()
        {
            InitializeComponent();
            _jokeService = DependencyService.Get<IJokeService>();

            DisplayJoke(_jokeService.GetRandomJoke());
        }

        private void NextJoke(object sender, EventArgs e)
        {
            DisplayJoke(_jokeService.GetRandomJoke());
        }

        private void DisplayJoke(Joke j)
        {
            QuestionLabel.Text = j.Question;
            AnswerLabel.Text = j.Answer;
            SentenceLabel.Text = j.Sentence;
        }
    }
}