using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.ViewModels
{
    public class TriggersPageViewModel : ViewModelBase
    {
        private string inputValue = "";
        public string InputValue
        {
            get => inputValue;
            set
            {
                SetProperty(ref inputValue, value);
                OnPropertyChanged(nameof(IsInputEmpty));
            }
        }

        public bool IsInputEmpty => string.IsNullOrEmpty(inputValue);
    }
}
