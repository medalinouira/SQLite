/// Mohamed Ali NOUIRA
/// http://www.sweetmit.com
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

using System.IO;
using Xamarin.Forms;
using SQLite.Helpers;
using Windows.Storage;
using SQLite.UWP.Helpers;

[assembly: Dependency(typeof(FileHelper))]
namespace SQLite.UWP.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
