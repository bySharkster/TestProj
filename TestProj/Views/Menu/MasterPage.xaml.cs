using System.Collections.Generic;
using TestProj.Models;
using TestProj.Views.DetailViews;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProj.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listview; } }
        public List<MasterMenuItem> items;
        public MasterPage()
        {
            InitializeComponent();
            SetItems();

        }
        void SetItems()
        {
            items = new List<MasterMenuItem>
            {//Added new item and changed previous items names
                new MasterMenuItem("Files", "LoginIcon.jpg", Color.FloralWhite, typeof(InfoScreen)),
                new MasterMenuItem("New", "LoginIcon.jpg", Color.FloralWhite, typeof(InfoScreen2)),
                new MasterMenuItem("Share", "LoginIcon.jpg", Color.FloralWhite, typeof(SelectFilesToShare))
            };
            ListView.ItemsSource = items;
        }
    }
}