using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProj.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProj.Views.DetailViews.SettingsViews 
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsScreen : ContentPage
    {
        Settings settings;
        SwitchCell switchCell1;
        SwitchCell switchCell2;
        //User currentUser;


        public SettingsScreen()
        {
            InitializeComponent();
            BackgroundColor = Constants.BackgroundColor;
            loadSettings();
            App.StartCheckIfInternet(lbl_NoInternet, this);
            Title = Constants.SettingsScreenTitle;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            App.StartCheckIfInternet(lbl_NoInternet, this);

        }

        private void loadSettings()
        {
            settings = App.SettingsDatabase.GetSettings();
            //currentUser = App.UserDatabase.GetUser();

            TableView table;

            switchCell1 = new SwitchCell
            {
                Text = "Switchcell 1",
                On = settings.switch1
            };
            switchCell1.OnChanged += (object sender, ToggledEventArgs e) =>
            {
                switchCell1Switched(sender, e);
            };

            switchCell2 = new SwitchCell
            {
                Text = "Switchcell 2",
                On = settings.switch2
            };
            switchCell1.OnChanged += (object sender, ToggledEventArgs e) =>
            {
                switchCell2Switched(sender, e);
            };

            table = new TableView
            {
                Root = new TableRoot
                {
                    new TableSection
                    {
                        switchCell1,
                        switchCell2
                    }
                }
            };

            table.VerticalOptions = LayoutOptions.FillAndExpand;

            MainLayout.Children.Add(table);

        }

        private void switchCell2Switched(object sender, ToggledEventArgs e)
        {
            settings.switch2 = e.Value;
        }

        private void switchCell1Switched(object sender, ToggledEventArgs e)
        {
            settings.switch1 = e.Value;
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();
            var action = await DisplayAlert("Settings", "Do you want to save the settings?", "Ok", "Cancel");
            SaveSettings();

        }

        private void SaveSettings()
        {
            App.SettingsDatabase.SaveSettings(settings);
        }
    }
}