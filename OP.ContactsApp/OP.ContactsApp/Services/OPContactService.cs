using OP.ContactsApp.Models;
using Plugin.ContactService;
using Plugin.ContactService.Shared;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OP.ContactsApp.Services
{
    public class OPContactService : IOPContactService
    {
        public OPContact SelectedContact { get; set; }

        private IContactService _contactService;

        public OPContactService(IContactService contactService)
        {
            _contactService = contactService ?? throw new ArgumentNullException(nameof(contactService));
        }

        public async Task<IEnumerable<OPContact>> GetContactsAsync()
        {
            var contacts = await _contactService.GetContactListAsync();
            return contacts.Select(ct => new OPContact()
            {
                Name = ct.Name,
                Email = ct.Email,
                Number = ct.Number,
                PhotoUri = ct.PhotoUri,
                PhotoUriThumbnail = ct.PhotoUriThumbnail,
            }).ToList();
        }
    }
}
