using OP.ContactsApp.Common;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                await App.Current.MainPage.Navigation.PushModalAsync(_container.GetInstance(type) as Page, false);
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
            => typeof(TViewModel).Assembly.GetType(typeof(TViewModel).FullName.TrimEnd("Model".ToArray()));
    }
}
