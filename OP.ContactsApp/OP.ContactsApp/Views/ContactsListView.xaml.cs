using OP.ContactsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OP.ContactsApp.Views
{
    public partial class ContactsListView : ContentPage
    {
        public ContactsListView(ContactsListViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private async void ContentPage_Appearing(object sender, EventArgs e)
        {
            var ctx = BindingContext as ContactsListViewModel;
            await ctx.Initialize();
        }
    }
}
