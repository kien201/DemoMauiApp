using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomControl.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private Stream globalStream;
        public Stream GlobalStream
        {
            get => globalStream;
            set => SetProperty(ref globalStream, value);
        }
    }

    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void SetProperty<T>(ref T property, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(property, value)) return;
            property = value;
            OnPropertyChanged(propertyName);
        }

        public virtual Task OnNavigateBack(object? parameter) => Task.CompletedTask;
        public virtual Task OnNavigate(object? parameter) => Task.CompletedTask;
    }
}
