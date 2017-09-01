using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using App4.Model;
using Xamarin.Forms;

namespace App4
{
	public partial class MainPage : ContentPage
	{
	    private JokeRepository _jokeRepo; 
		public MainPage()
		{
			InitializeComponent();
            _jokeRepo = new JokeRepository();
           DisplayJoke(_jokeRepo.GetRandom());
        }

	    private void NextJoke(object sender, EventArgs e)
	    {
            DisplayJoke(_jokeRepo.GetRandom());
        }

	    private void DisplayJoke(Joke j)
	    {
            QuestionLabel.Text = j.Question;
	        AnswerLabel.Text = j.Answer;
	        SentenceLabel.Text = j.Sentence;
	    }
	}
}
