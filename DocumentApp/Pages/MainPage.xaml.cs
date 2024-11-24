using DocumentApp.Models;
using DocumentApp.ViewModels;

namespace DocumentApp.Pages;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}