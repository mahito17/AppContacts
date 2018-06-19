using System;
using System.IO;
using AppContacts.Services;
using AppContacts.iOS.Services;
using Xamarin.Forms;
using UIKit;
[assembly: Dependency(typeof(FileHelper))]
namespace AppContacts.iOS.Services
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, fileName);
        }
    }
}