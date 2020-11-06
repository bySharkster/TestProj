
using TestProj.Views.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestProj.Views.DetailViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoScreen2 : ContentPage
    {
        public InfoScreen2()
        {
            InitializeComponent();
        }

        private async void New_Parameter_Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewParameter());
        }

        private async void New_Form_Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new NewForm());
        }
    }
}