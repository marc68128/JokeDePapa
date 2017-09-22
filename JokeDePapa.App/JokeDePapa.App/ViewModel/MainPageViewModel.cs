using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using JokeDePapa.Service.Contracts;
using JokeDePapa.Service.Services;
using Xamarin.Forms;

namespace JokeDePapa.App.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IJokeService _jokeService;
        private readonly List<int> _alreadySeenJokesId;  

        public MainPageViewModel(IJokeService jokeService = null)
        {
            _alreadySeenJokesId = new List<int>();
            _jokeService = jokeService ?? DependencyService.Get<IJokeService>();

            InitCommand();
        }

        private string _question;
        private string _answer;
        private string _sentence;

        public string Sentence
        {
            get { return _sentence; }
            set
            {
                _sentence = value;
                OnPropertyChanged();
            }
        }
        public string Answer
        {
            get { return _answer; }
            set
            {
                _answer = value;
                OnPropertyChanged();
            }
        }
        public string Question
        {
            get { return _question; }
            set
            {
                _question = value;
                OnPropertyChanged();
            }
        }

        public ICommand NextJokeCommand { get; set; }

        private void InitCommand()
        {
            NextJokeCommand = new Command(() =>
            {
                var joke = _jokeService.GetRandomJoke(_alreadySeenJokesId);

                if (joke == null)
                    return; //ToDO : manage no more joke case

                _alreadySeenJokesId.Add(joke.Id);

                Sentence = joke.Sentence;
                Answer = joke.Answer;
                Question = joke.Question;
            });
        }
    }
}
