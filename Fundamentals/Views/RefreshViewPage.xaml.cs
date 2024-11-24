using Fundamentals.ViewModels;

namespace Fundamentals.Views;

public partial class RefreshViewPage : ContentPage
{
	public RefreshViewPage(RefreshViewPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}