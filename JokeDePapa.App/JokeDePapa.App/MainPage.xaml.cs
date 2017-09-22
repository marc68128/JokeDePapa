using JokeDePapa.App.ViewModel;
using Xamarin.Forms;

namespace JokeDePapa.App
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}