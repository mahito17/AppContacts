using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppContacts.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppContacts

{
    using AppContacts.Services;
    using AppContacts.Data;
    using System.Diagnostics;
    public partial class App : Application
    {
        public static ContacsDatabase dataBase;
        public static ContacsDatabase DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    try
                    {
                        dataBase = new ContacsDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("contacts.db3"));
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        throw;
                    }
                }
                return dataBase;
            }
            set
            {
                dataBase = value;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.ContactsPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
