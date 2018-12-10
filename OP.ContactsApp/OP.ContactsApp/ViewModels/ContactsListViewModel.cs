using OP.ContactsApp.Common;
using OP.ContactsApp.Services;
using Plugin.ContactService;
using Plugin.ContactService.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace OP.ContactsApp.ViewModels
{
    public class ContactsListViewModel : ViewModelBase
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public bool IsBusy { get; set; }
        public bool IsInitiailized { get; set; }

        public ICommand ContactSelectedCommand { get; private set; }

        private IOPContactService _contactService;
        private INavigationService _navigationService;

        public ContactsListViewModel(IOPContactService contactService, INavigationService navigationService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            ContactSelectedCommand = new Command<ItemTappedEventArgs>(OnContactSelected);
        }

        public async Task Initialize()
        {
            if (IsInitiailized) return;
            IsBusy = true;            
            Contacts = await _contactService.GetContactsAsync();
            Contacts = Contacts.OrderBy(contact => contact.Name);
            IsBusy = false;
            IsInitiailized = true;
        }

        private void OnContactSelected(ItemTappedEventArgs e)
        {
            var contact = e.Item as Contact;
            _contactService.SelectedContact = contact;
            _navigationService.OpenModal<ContactDetailViewModel>();
        }
    }
}
