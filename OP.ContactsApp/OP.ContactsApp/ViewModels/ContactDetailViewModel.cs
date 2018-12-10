using OP.ContactsApp.Common;
using OP.ContactsApp.Models;
using OP.ContactsApp.Services;
using System;
using Xamarin.Forms;

namespace OP.ContactsApp.ViewModels
{
    public class ContactDetailViewModel : ViewModelBase
    {

        private IOPContactService _contactService;
        private IMessagingCenter _messagingCenter;

        public OPContact SelectedContact { get; set; }      

        public ContactDetailViewModel(IOPContactService contactService, IMessagingCenter messagingCenter)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
            _messagingCenter = messagingCenter ?? throw new ArgumentNullException(nameof(messagingCenter));
            SelectedContact = _contactService.SelectedContact;
        }

        public void OnBackButtonPressed()
        {
            if (SelectedContact.Favorite)
                _messagingCenter.Send(this, "ClearFavorites", SelectedContact);
        }
    }
}
