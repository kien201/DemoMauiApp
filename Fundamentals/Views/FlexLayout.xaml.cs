using Fundamentals.ViewModels;

namespace Fundamentals.Views;

public partial class FlexLayout : ContentPage
{
	public FlexLayout()
	{
		InitializeComponent();
		BindingContext = new FlexLayoutViewModel();
	}
}