using System;
using System.Threading;
using System.Threading.Tasks;
using TestProj.Data;
using TestProj.Models;
using TestProj.Views;
using Xamarin.Forms;

namespace TestProj
{
    public partial class App : Application
    {
        static TokenDatabaseController tokenDatabase; //user password controller
        static UserDatabaseController userDatabase;   //user controller
        static SettingsDatabaseController settingsDatabase; //settings dabase controller


        static RestService restService;               //
        private static Label labelScreen;
        private static bool hasInternet;              //Has Internet or Not
        private static Page currentpage;              //
        private static Timer timer;                   //
        private static bool noInterShow;              //Show user that hasn't internet

        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }
        public static TokenDatabaseController TokenDatabase
        {
            get
            {
                if (tokenDatabase == null)
                {
                    tokenDatabase = new TokenDatabaseController();
                }
                return tokenDatabase;
            }
        }

        public static SettingsDatabaseController SettingsDatabase
        {
            get
            {
                if (settingsDatabase == null)
                {
                    settingsDatabase = new SettingsDatabaseController();
                }
                return settingsDatabase;
            }
        }
        public static RestService RestService
        {
            get
            {
                if (restService == null)
                {
                    restService = new RestService();
                }
                return restService;
            }
        }


        //-------------------------------Internet Connection-----------------------------

        public static void StartCheckIfInternet(Label label, Page page)
        {
            labelScreen = label;
            label.Text = (string)Constants.NoInternetText;
            label.IsVisible = false;
            hasInternet = true;
            currentpage = page;
            if (timer == null)
            {
                timer = new Timer((e) =>
               {
                   CheckIfInternetOverTime();
               }, null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }

        private static void CheckIfInternetOverTime()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await ShowDisplayAlert();
                        }
                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                    {
                        hasInternet = true;
                        labelScreen.IsVisible = false;
                    });
            }
        }
        public static bool CheckIfInternetAlert()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            return networkConnection.IsConnected;
        }

        public static async Task<bool> CheckIfInternet()
        {
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.IsConnected)
            {
                if (!noInterShow)
                {
                    await ShowDisplayAlert();
                }
                return false;
            }
            return true;

        }
        private static async Task ShowDisplayAlert()
        {
            noInterShow = false;
            await currentpage.DisplayAlert("Internet", "Device has no internet, please reconnect", "Ok");
            noInterShow = false;
        }
    }
}


