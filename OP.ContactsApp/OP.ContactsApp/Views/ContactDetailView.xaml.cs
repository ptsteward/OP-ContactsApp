using OP.ContactsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OP.ContactsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailView : ContentPage
    {
        public ContactDetailView(ContactDetailViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}