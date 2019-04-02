using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            await Navigation.PushModalAsync(new tabbedPage());
        }
        async void OnTapGestureRecognizerTapped(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateUser());
        }
    }
}
