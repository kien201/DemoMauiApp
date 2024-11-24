using AndroidX.Lifecycle;
using CommunityToolkit.Maui.Core.Extensions;
using CustomControl.ViewModels;

namespace CustomControl.Views
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            this.viewModel = viewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            viewModel.GlobalStream = await signaturePad.GetImageStream(625, 200);
            signatureImage.Source = ImageSource.FromStream(() => viewModel.GlobalStream);
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            signaturePad.Clear();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            signatureImage.IsVisible = !signatureImage.IsVisible;
        }
    }

}
