using OP.ContactsApp.Common;
using OP.ContactsApp.Models;
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
        public IEnumerable<OPContact> Contacts { get; set; }
        public bool IsBusy { get; set; }
        public bool IsInitiailized { get; set; }

        public ICommand ContactSelectedCommand { get; private set; }

        private IOPContactService _contactService;
        private INavigationService _navigationService;
        private IMessagingCenter _messagingCenter;

        public ContactsListViewModel(IOPContactService contactService, INavigationService navigationService, IMessagingCenter messagingCenter)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            _messagingCenter = messagingCenter ?? throw new ArgumentNullException(nameof(messagingCenter));
            ContactSelectedCommand = new Command<ItemTappedEventArgs>(OnContactSelected);
            _messagingCenter.Subscribe<ContactDetailViewModel, OPContact>(this, "ClearFavorites", (vm, ctc) => Contacts.ToList().ForEach(contact =>
            {
                if (ctc != contact)
                    contact.Favorite = false;
            }));
        }

        public async Task Initialize()
        {
            if (Contacts != null && Contacts.Any()) Contacts = SortContacts(Contacts);
            if (IsInitiailized) return;
            IsBusy = true;
            var contacts = await _contactService.GetContactsAsync();
            Contacts = SortContacts(contacts);
            IsBusy = false;
            IsInitiailized = true;
        }

        private void OnContactSelected(ItemTappedEventArgs e)
        {
            var contact = e.Item as OPContact;
            _contactService.SelectedContact = contact;
            _navigationService.OpenModal<ContactDetailViewModel>();
        }

        private IEnumerable<OPContact> SortContacts(IEnumerable<OPContact> contacts)
            => contacts.OrderByDescending(contact => contact.Favorite).ThenBy(contact => contact.Name).ToList();
    }
}
