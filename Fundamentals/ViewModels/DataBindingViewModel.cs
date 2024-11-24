using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fundamentals.ViewModels
{
    public class DataBindingViewModel : ViewModelBase
    {
        private int inputValue;
        public int InputValue
        {
            get => inputValue;
            set
            {
                SetProperty(ref inputValue, value);
                ChangeCanExecutes();
            }
        }

        public ICommand ChangeInputValueCommand { get; }

        private void ChangeInputValue()
        {
            InputValue = 50;
            ChangeCanExecutes();
        }

        public DataBindingViewModel()
        {
            InputValue = 10;
            ChangeInputValueCommand = new Command(ChangeInputValue, () => InputValue != 50);
        }

        private void ChangeCanExecutes()
        {
            (ChangeInputValueCommand as Command)?.ChangeCanExecute();
        }
    }
}
