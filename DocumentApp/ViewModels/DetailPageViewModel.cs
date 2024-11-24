using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DocumentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentApp.ViewModels
{
    public partial class DetailPageViewModel : ViewModelBase
    {
        [ObservableProperty]
        //[NotifyPropertyChangedFor(nameof(IsDocumentExist))]
        //[NotifyCanExecuteChangedFor(nameof(ShowCommand))]
        private Document? document;

        //[RelayCommand]
        //void Show()
        //{

        //}

        //public bool IsDocumentExist => Document != null;

        //partial void OnDocumentChanged(Document? value)
        //{
        //    OnPropertyChanged(nameof(IsDocumentExist));
        //}

        public override Task OnNavigate(object? parameter)
        {
            Document = parameter as Document;
            return base.OnNavigate(parameter);
        }
    }
}
