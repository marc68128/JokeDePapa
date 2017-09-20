using System;
using JokeDePapa.Data.Contracts;
using JokeDePapa.Data.Repositories;
using JokeDePapa.Domain.Model;
using Xamarin.Forms;

namespace JokeDePapa.App
{
    public partial class MainPage : ContentPage
	{
	    private IJokeRepository _jokeRepo; 
		public MainPage()
		{
			InitializeComponent();

		    try
		    {
		        _jokeRepo = DependencyService.Get<IJokeRepository>();
		        _jokeRepo.Create(new Joke {Question = "TestQ", Answer = "TestA"});
		        var res = _jokeRepo.GetAll();
		    }
		    catch (Exception e)
		    {
		        Console.WriteLine(e);
		    }

		    //DisplayJoke(_jokeRepo.GetRandom());
		}

	    private void NextJoke(object sender, EventArgs e)
	    {
            //DisplayJoke(_jokeRepo.GetRandom());
        }

	    private void DisplayJoke(Joke j)
	    {
            QuestionLabel.Text = j.Question;
	        AnswerLabel.Text = j.Answer;
	        SentenceLabel.Text = j.Sentence;
	    }
	}
}