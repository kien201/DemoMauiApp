using DemoMauiApp.Services;
using DemoMauiApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace DemoMauiApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<string> Items { get; set; }

        string inputText;
        public string InputText
        {
            get => inputText;
            set => SetProperty(ref inputText, value);
        }

        public ICommand AddCommand { get; }
        void Add()
        {
            if (string.IsNullOrEmpty(InputText)) return;

            Items.Add(InputText);
            InputText = string.Empty;
        }
        public ICommand DeleteCommand { get; }
        void Delete(string item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }
        public ICommand DetailCommand { get; }
        async void Detail(string item)
        {
            if (Items.Contains(item))
            {
                await NavigationService.NavigateToPage<DetailPage>(item);
            }
        }

        public MainPageViewModel(NavigationService navigationService)
            : base(navigationService)
        {
            Items = new ObservableCollection<string>() { "Dog", "Cat", "Monkey" };

            AddCommand = new Command(Add);
            DeleteCommand = new Command<string>(Delete);
            DetailCommand = new Command<string>(Detail);
        }

        public override Task OnNavigateBack(object? parameter)
        {
            return base.OnNavigateBack(parameter);
        }
    }
}
