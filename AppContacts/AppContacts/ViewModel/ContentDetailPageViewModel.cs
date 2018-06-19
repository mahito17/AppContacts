using AppContacts.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppContacts.ViewModel
{
    public class ContentDetailPageViewModel
    {
        public Contact CurrentContacts { get; set; }
        public Command SaveContactCommand { get; set; }
        public Command DeleteContactCommand { get; set; }
        public INavigation Navigation { get; set; }

        public ContentDetailPageViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.CurrentContacts = new Contact();
            SaveContactCommand = new Command(async () => await SaveContact());
            DeleteContactCommand = new Command(async () => await DeleteContact());
        }

        private async Task SaveContact()
        {
            await App.DataBase.SaveItemAsync(CurrentContacts);
            await Navigation.PopToRootAsync();
        }

        private async Task DeleteContact()
        {
            await App.DataBase.DeleteItemAsync(CurrentContacts);
            await Navigation.PopToRootAsync();
        }
    }
}
