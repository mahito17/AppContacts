using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppContacts.ViewModel;

namespace AppContacts.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : ContentPage
    {
        public ContactsPageViewModel ViewModel { get; set; }
        public ContactsPage()
        {
            InitializeComponent();

            ViewModel = new ContactsPageViewModel(Navigation);
            this.BindingContext = ViewModel;
        }
    }
}