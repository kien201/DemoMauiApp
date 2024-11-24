using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fundamentals.ViewModels
{
    public class DemoPageViewModel : ViewModelBase
    {
        private bool isVisible;
        public bool IsVisible
        {
            get => isVisible;
            set => SetProperty(ref isVisible, value);
        }

        private ICommand toggleVisibleCommand;
        public ICommand ToggleVisibleCommand => toggleVisibleCommand ??= new Command(ToggleVisible);

        private void ToggleVisible()
        {
            IsVisible = !IsVisible;
        }

        public DemoPageViewModel()
        {
            IsVisible = false;
        }
    }
}
