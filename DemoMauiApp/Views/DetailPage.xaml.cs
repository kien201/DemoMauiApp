using DemoMauiApp.ViewModels;

namespace DemoMauiApp.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}