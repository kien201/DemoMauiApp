using Fundamentals.ViewModels;

namespace Fundamentals.Views;

public partial class TriggersPage : ContentPage
{
	public TriggersPage()
	{
		InitializeComponent();
		BindingContext = new TriggersPageViewModel();

    }
}