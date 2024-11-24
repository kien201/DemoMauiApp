using DemoMauiApp.ViewModels;

namespace DemoMauiApp.Views;

public partial class WIEformPage : ContentPage
{
	public WIEformPage(WIEformPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}