using OP.ContactsApp.Common;
using System;
using System.Linq;

namespace OP.ContactsApp.Services
{
    public interface INavigationService
    {
        void OpenModal<TViewModel>() where TViewModel : ViewModelBase;
        void CloseModal();
    }
}
