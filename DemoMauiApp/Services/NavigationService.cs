using DemoMauiApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMauiApp.Services
{
    public class NavigationService
    {
        readonly IServiceProvider _services;

        protected INavigation Navigation
        {
            get
            {
                INavigation? navigation = Application.Current?.MainPage?.Navigation;
                if (navigation is not null)
                    return navigation;
                else
                {
                    //This is not good!
                    if (Debugger.IsAttached)
                        Debugger.Break();
                    throw new Exception();
                }
            }
        }

        public NavigationService(IServiceProvider services) => _services = services;

        public async Task NavigateBack(object? parameter = null)
        {
            if (Navigation.NavigationStack.Count > 1)
            {
                var viewModel = GetPageViewModelBase(Navigation.NavigationStack.SkipLast(1).LastOrDefault());
                if (viewModel is not null) await viewModel.OnNavigateBack(parameter);
                await Navigation.PopAsync();
                return;
            }

            throw new InvalidOperationException("No pages to navigate back to!");
        }

        private ViewModelBase? GetPageViewModelBase(Page? p) => p?.BindingContext as ViewModelBase;

        public async Task NavigateToPage<T>(object? parameter = null) where T : Page
        {
            var page = _services.GetService<T>();

            if (page is not null)
            {
                page.Appearing += async (sender, e) =>
                {
                    var toViewModel = GetPageViewModelBase(page);
                    if (toViewModel is not null)
                        await toViewModel.OnNavigate(parameter);
                };

                await Navigation.PushAsync(page, true);
            }
            else
                throw new InvalidOperationException($"Unable to resolve type {typeof(T).FullName}");
        }
    }
}
