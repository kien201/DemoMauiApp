namespace Fundamentals
{
    [QueryProperty(nameof(Text), "Text")]
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public string? Text { get; set; }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Text is not null) CounterBtn.Text += Text;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
