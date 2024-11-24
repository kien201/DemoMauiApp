using Fundamentals.ViewModels;
using Microsoft.Maui.Controls;

namespace Fundamentals.Views;

public partial class DataBindingPage : ContentPage
{
	public DataBindingPage()
	{
		InitializeComponent();
        BindingContext = new DataBindingViewModel();
    }
}