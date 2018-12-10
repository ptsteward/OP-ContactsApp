using OP.ContactsApp.Common;
using SimpleInjector;
using System;
using Xamarin.Forms;

namespace OP.ContactsApp.Services
{
    public class NavigationService : INavigationService
    {

        private readonly Container _container;

        public NavigationService(Container container) => _container = container ?? throw new ArgumentNullException(nameof(container));

        public void OpenModal<TViewModel>() where TViewModel : ViewModelBase
        {
            var type = GetViewType<TViewModel>();
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(_container.GetInstance(type) as Page, false);
            });
        }

        public void CloseModal()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await App.Current.MainPage.Navigation.PopModalAsync(false);
            });
        }

        private Type GetViewType<TViewModel>()
            => typeof(TViewModel).Assembly.GetType(typeof(TViewModel).FullName.Replace("Model",""));
    }
}
