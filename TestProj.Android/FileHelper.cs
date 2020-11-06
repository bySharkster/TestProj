using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Xamarin.Forms;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Environment = System.Environment;

[assembly: Dependency(typeof(TestProj.Droid.FileHelper))] // Dependency defined. Later accesed by TestProj.FileHelper

namespace TestProj.Droid
{
    class FileHelper : IFileHelper // IFileHelper is an interface defined in TestProj
    {
        public void CreateFolder(string filename)
        {
            string filenamepath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            Directory.CreateDirectory(filenamepath);
        }

        public void CreateRootFolder()
        {
            string appdir = GetDocsPath();
            string myfilespath = Path.Combine(appdir, "My Files");
            Directory.CreateDirectory(myfilespath);
            Directory.SetCurrentDirectory(myfilespath);

        }

        public IEnumerable<string> GetFiles()
        {
            return Directory.EnumerateDirectories(Directory.GetCurrentDirectory());
        }

        string GetDocsPath() // Utility method used for implementing IFileHelper.
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }
    }
}