using Plugin.ContactService.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OP.ContactsApp.Services
{
    public interface IOPContactService
    {
        Task<IList<Contact>> GetContactsAsync();
        Contact SelectedContact { get; set; }
    }
}
