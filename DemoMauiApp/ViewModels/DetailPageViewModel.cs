using DemoMauiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoMauiApp.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        string text;
        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public ICommand BackCommand { get; }
        async void Back()
        {
            await NavigationService.NavigateBack("123");
        }

        public DetailPageViewModel(NavigationService navigationService)
            : base(navigationService)
        {
            BackCommand = new Command(Back);
        }

        public override Task OnNavigate(object? parameter)
        {
            Text = parameter?.ToString() ?? string.Empty;
            return base.OnNavigate(parameter);
        }
    }
}
