using OP.ContactsApp.Common;
using OP.ContactsApp.Services;
using Plugin.ContactService.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace OP.ContactsApp.ViewModels
{
    public class ContactDetailViewModel : ViewModelBase
    {

        private IOPContactService _contactService;
        private INavigationService _navigationService;

        public Contact SelectedConatct { get; set; }

        public ContactDetailViewModel(IOPContactService contactService, INavigationService navigationService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            SelectedConatct = _contactService.SelectedContact;
        }
    }
}
