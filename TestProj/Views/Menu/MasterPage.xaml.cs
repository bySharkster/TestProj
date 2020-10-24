using System.Collections.Generic;
using TestProj.Models;
using TestProj.Views.DetailViews;
using TestProj.Views.DetailViews.SettingsViews;
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
            items = new List<MasterMenuItem>();
            items.Add(new MasterMenuItem("InfoScreen", "LoginIcon.jpg", Color.FloralWhite, typeof(InfoScreen)));
            items.Add(new MasterMenuItem("InfoScreen2", "LoginIcon.jpg", Color.FloralWhite, typeof(InfoScreen2)));
            items.Add(new MasterMenuItem("Settings", "LoginIcon.jpg", Color.FloralWhite, typeof(SettingsScreen)));
            ListView.ItemsSource = items;
        }
    }
}