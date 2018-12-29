using System;
using System.IO;
using TestCI.Database;
using TestCI.Droid.Helpers;

using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]

namespace TestCI.Droid.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, filename);
        }
    }
}