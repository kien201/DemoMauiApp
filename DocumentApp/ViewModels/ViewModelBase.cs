using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DocumentApp.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
        public virtual Task OnNavigate(object? parameter) => Task.CompletedTask;
        public virtual Task OnNavigateBack(object? parameter) => Task.CompletedTask;
    }
}
