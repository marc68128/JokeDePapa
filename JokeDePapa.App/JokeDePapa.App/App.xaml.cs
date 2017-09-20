using JokeDePapa.Domain.Model;
using SQLite;
using Xamarin.Forms;

namespace JokeDePapa.App
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
			MainPage = new MainPage();
		}

		protected override void OnStart()
		{

			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}

        private string CreateDatabase(string path)
        {
            try
            {
                var connection = new SQLiteAsyncConnection(path);
                connection.CreateTableAsync<Joke>();
                return "Database created";
            }
            catch (SQLiteException ex)
            {
                return ex.Message;
            }
        }
    }
}

