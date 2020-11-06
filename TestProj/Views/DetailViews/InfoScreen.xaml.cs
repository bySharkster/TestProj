
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProj.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoScreen : ContentPage
    {
        FileHelper fileHelper = new FileHelper(); // Utility class for performing file functions.
        public InfoScreen()
        {
            InitializeComponent();
            //Init();
            fileHelper.CreateRootFolder(); // Creates folder where all user folder/file creation will occur.
            RefreshListView();
        }

        void Init()
        {
            //ActivitySpinner.IsVisible = true;
        }

        private void Add_Folder_Button_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                fileHelper.CreateFolder(folderNameEntry.Text);
                RefreshListView();
                folderNameEntry.Text = null;
            }
            catch
            {
                // Display alert.
            }
        }

        private void Refresh_List_Button_Clicked(object sender, System.EventArgs e)
        {
            RefreshListView();
        }

        void RefreshListView()
        {
            listView.ItemsSource = fileHelper.GetFiles();
            listView.SelectedItem = null;
        }
    }
}