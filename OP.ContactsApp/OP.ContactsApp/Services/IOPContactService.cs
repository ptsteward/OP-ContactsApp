using OP.ContactsApp.Models;
using Plugin.ContactService.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OP.ContactsApp.Services
{
    public interface IOPContactService
    {
        Task<IEnumerable<OPContact>> GetContactsAsync();
        OPContact SelectedContact { get; set; }
    }
}
