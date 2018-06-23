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
                async () => await GoToDetailContact()
                );
        }

        private async Task GoToDetailContact()
        {
            await Navigation.PushAsync(new ContactDetailPage());
        }
        #region Propiedades
        public Contact CurrentContact { get; set; }
        public Command AddCurrentCommand { get; set; }
        public Command ItemTappedCommand { get; }
        #endregion


        public ContactsPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Task.Run(async () =>
            ContactsLists = await App.DataBase.GetItemsGroupedAsync()).Wait();
            AddContactComand = new Command(async () => await
            GoToContactDetailPage());
            ItemTappedCommand = new Command(async () => GoToContactsDetailPage(CurrentContact));

        }

        private Task GoToContactDetailPage()
        {
            throw new NotImplementedException();
        }

        //No Olvidar revisar!!!!!
        public async Task GoToContacDetailPage(Contact contact = null)
        {
            if (contact == null)
            {
                await Navigation.PushAsync(new ContactDetailPage());

            }
            else
            {
                await Navigation.PushAsync(new ContactDetailPage(CurrentContact());
            }
        }
    }
}
