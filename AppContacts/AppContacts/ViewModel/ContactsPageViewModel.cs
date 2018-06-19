using AppContacts.Helpers;
using AppContacts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppContacts.ViewModel

{
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using AppContacts.View;

    public class ContactsPageViewModel
    {
        public ObservableCollection<Grouping<string, Contact>> ContactsLists { get; set; }
        public Command AddContactComand { get; set; }
        public INavigation Navigation { get; set; }

        public ContactsPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            Task.Run(async () => ContactsLists = await App.DataBase.GetAllGrouped()).Wait();

            AddContactComand = new Command(
                async () => await GoToDetailContact());
        }

        private async Task GoToDetailContact()
        {
            await Navigation.PushAsync(new ContactDetailPage());
        }
    }

}
