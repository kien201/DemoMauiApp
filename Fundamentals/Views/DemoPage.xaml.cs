using Fundamentals.ViewModels;

namespace Fundamentals.Views;

public partial class DemoPage : ContentPage
{
	public DemoPage(DemoPageViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}