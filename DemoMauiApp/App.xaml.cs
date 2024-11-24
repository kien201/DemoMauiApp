using DemoMauiApp.Services;
using DemoMauiApp.Views;

namespace DemoMauiApp
{
    public partial class App : Application
    {
        public App(NavigationService navigationService)
        {
            InitializeComponent();

            MainPage = new NavigationPage();
            navigationService.NavigateToPage<WIEformPage>();
        }
    }
}
