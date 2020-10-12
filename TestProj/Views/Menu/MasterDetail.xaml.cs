using System;
using TestProj.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProj.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            masterpage.ListView.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MasterMenuItem item)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterpage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}