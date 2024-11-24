using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fundamentals.ViewModels
{
    public class RefreshViewPageViewModel : ViewModelBase
    {
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }

        public ObservableCollection<int> Items { get; }

        private ICommand refreshCommand;
        public ICommand RefreshCommand => refreshCommand ??= new Command(async () => await Refresh());

        private ICommand loadCommand;
        public ICommand LoadCommand => loadCommand ??= new Command(async () => await Load());

        public RefreshViewPageViewModel()
        {
            Items = new ObservableCollection<int>();
        }

        public async Task Load()
        {
            await Task.Delay(1000);
            Items.Clear();
            for (int i = 0; i < 100; i++)
            {
                Items.Add(i);
            }
        }

        public async Task Refresh()
        {
            //if (IsRefreshing) return;

            //IsRefreshing = true;
            await Load();
            IsRefreshing = false;
        }
    }
}
