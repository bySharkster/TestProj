using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.IO;

namespace TestProj
{
    class FileHelper : IFileHelper // FileHelper is a utility class that accesses a dependency service and acts as its reflection.
    {
        IFileHelper fileHelper = DependencyService.Get<IFileHelper>(); // Dependency defined in TestProj.Android.FileHelper
        public void CreateFolder(string filename)
        {
            fileHelper.CreateFolder(filename);
        }

        public void CreateRootFolder()
        {
            fileHelper.CreateRootFolder();
        }

        public IEnumerable<string> GetFiles()
        {
            IEnumerable<string> filepaths = fileHelper.GetFiles();
            List<string> filenames = new List<string>();
            foreach (string filepath in filepaths)
            {
                filenames.Add(Path.GetFileName(filepath));
            }
            return filenames;
        }
    }
}
