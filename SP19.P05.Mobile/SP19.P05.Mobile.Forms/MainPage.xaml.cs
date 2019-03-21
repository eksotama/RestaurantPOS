using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
namespace SP19.P05.Mobile.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void Button_Clicked(object sender, System.EventArgs e)
        {
            var pushPage = new TabbedDisplay.CheckIn();
            await Navigation.PushModalAsync(pushPage);
        }
    }
}
