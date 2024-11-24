using DemoMauiApp.ViewModels;

namespace DemoMauiApp.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}