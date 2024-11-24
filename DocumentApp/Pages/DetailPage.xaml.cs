using DocumentApp.ViewModels;

namespace DocumentApp.Pages;

public partial class DetailPage : ContentPage
{
	readonly DetailPageViewModel detailPageViewModel;

    public DetailPage(DetailPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = detailPageViewModel = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        //Title = detailPageViewModel.Document?.Name ?? "Detail";
        //DocumentWebView.Source = new UrlWebViewSource() { Url = };
    }
}