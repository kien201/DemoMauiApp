using DemoMauiApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoMauiApp.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        protected NavigationService NavigationService;
        protected ViewModelBase(NavigationService service)
        {
            NavigationService = service;
        }

        public virtual Task OnNavigateBack(object? parameter) => Task.CompletedTask;
        public virtual Task OnNavigate(object? parameter) => Task.CompletedTask;
    }

    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool SetProperty<T>(ref T property, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(property, value)) return false;
            property = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
