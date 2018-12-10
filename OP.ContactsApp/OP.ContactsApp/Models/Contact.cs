using Plugin.ContactService.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace OP.ContactsApp.Models
{
    public class OPContact : Contact
    {
        public bool Favorite { get; set; }
    }
}
