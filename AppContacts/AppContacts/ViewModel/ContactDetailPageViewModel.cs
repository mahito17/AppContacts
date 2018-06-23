using AppContacts.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppContacts.ViewModel
{
    public class ContactDetailPageViewModel
    {
        public Contact CurrentContact { get; set; }
        public Command SaveContactCommand { get; set; }
        public Command DeleteContactCommand { get; set; }
        public INavigation Navigation { get; set; }

        public ContactDetailPageViewModel(INavigation navigation, Contact contact = null)
        {
            this.Navigation = navigation;
            if (contact == null)
            {
                this.CurrentContact = new Contact();
            }
            else
            {
                this.CurrentContact = contact;
            }

            SaveContactCommand = new Command(async () => await SaveContact());
            DeleteContactCommand = new Command(async () => await DeleteContact());
        }

        private async Task SaveContact()
        {
            await App.DataBase.SaveItemAsync(CurrentContact);
            await Navigation.PopToRootAsync();
        }

        private async Task DeleteContact()
        {
            await App.DataBase.DeleteItemAsync(CurrentContact);
            await Navigation.PopToRootAsync();
        }
    }
}
