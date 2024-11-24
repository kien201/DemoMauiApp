namespace Fundamentals.Views;

public partial class LayoutPage : ContentPage
{
	public LayoutPage()
	{
		InitializeComponent();
    }

	private void Navigate(object sender, EventArgs e)
	{
		var b = Shell.Current.CurrentState;
		var c = Shell.Current.CurrentItem;
        var a = Shell.Current.GoToAsync("//MainPage", new ShellNavigationQueryParameters()
		{
			{ "Text", "Text from layout" }
		});
		a.Wait();
	}
}