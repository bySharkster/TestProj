using System;
using System.Collections.Generic;
using System.Text;

namespace TestProj
{
    public interface IFileHelper // This interface is implemented by TestProj.Android.FileHelper and its reflection TestProj.FileHelper
    {
        void CreateRootFolder();
        void CreateFolder(string filename);
        IEnumerable<string> GetFiles();
    }
}
