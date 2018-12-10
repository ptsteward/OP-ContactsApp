using OP.ContactsApp.Common;

namespace OP.ContactsApp.Services
{
    public interface INavigationService
    {
        void OpenModal<TViewModel>() where TViewModel : ViewModelBase;
        void CloseModal();
    }
}
