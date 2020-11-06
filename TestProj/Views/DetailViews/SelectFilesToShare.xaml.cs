using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProj.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectFilesToShare : ContentPage
    {
        FileHelper fileHelper = new FileHelper();
        public SelectFilesToShare()
        {
            InitializeComponent();
            RefreshListView();
        }

        void RefreshListView()
        {
            listView.ItemsSource = fileHelper.GetFiles();
            listView.SelectedItem = null;
        }
    }
}