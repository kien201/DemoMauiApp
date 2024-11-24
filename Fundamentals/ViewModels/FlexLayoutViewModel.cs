using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.ViewModels
{
    public class FlexLayoutViewModel : ViewModelBase
    {
        public ObservableCollection<int> Items { get; }
        public FlexLayoutViewModel()
        {
            Items = new ObservableCollection<int>() { 1, 2, 3, 4, 5, 6, 7};
        }
    }
}
