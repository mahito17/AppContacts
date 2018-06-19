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
	public partial class ContactDetailPage : ContentPage
	{
        public ContentDetailPageViewModel ViewModel { get; set; }
        public ContactDetailPage ()
		{
			InitializeComponent ();
            ViewModel = new ContentDetailPageViewModel(Navigation);
            this.BindingContext = ViewModel;
		}
	}
}