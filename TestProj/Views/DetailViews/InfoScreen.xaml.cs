
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProj.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoScreen : ContentPage
    {
        public InfoScreen()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            ActivitySpinner.IsVisible = false;
        }
    }
}