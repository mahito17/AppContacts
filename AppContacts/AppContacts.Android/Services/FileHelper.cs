using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using System.IO;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppContacts.Droid.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]

namespace AppContacts.Droid.Services

{
    using AppContacts.Services;
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);

        }
    }
}