using OP.ContactsApp.Common;
using Plugin.ContactService;
using Plugin.ContactService.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.ContactsApp.ViewModels
{
    public class ContactsListViewModel : ViewModelBase
    {
        public IEnumerable<Contact> Contacts { get; set; }
        public bool IsBusy { get; set; }

        private IContactService _contactService;

        public ContactsListViewModel(IContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));            
        }

        public async Task Initialize()
        {
            IsBusy = true;
            Contacts = await _contactService.GetContactListAsync();
            IsBusy = false;
        }
    }
}
