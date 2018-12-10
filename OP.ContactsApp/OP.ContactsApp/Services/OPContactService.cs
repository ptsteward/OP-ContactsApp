using Plugin.ContactService;
using Plugin.ContactService.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OP.ContactsApp.Services
{
    public class OPContactService : IOPContactService
    {
        public Contact SelectedContact { get; set; }

        private IContactService _contactService;

        public OPContactService(IContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }        

        public Task<IList<Contact>> GetContactsAsync() => _contactService.GetContactListAsync();
    }
}
