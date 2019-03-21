using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace SP19.P05.Mobile.Forms.TabbedDisplay
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckIn : ContentPage
	{
        ZXingScannerPage scanPage;
        public CheckIn ()
		{
			InitializeComponent();
            scanTableClicked.Clicked += scanTableClicked_Clicked;
            waiting.Clicked += waiting_Clicked;
		}

        private async void waiting_Clicked(object sender, EventArgs e)
        {
            var pushPage = new tabbedPage();
            await Navigation.PushModalAsync(pushPage);
        }

        private async void scanTableClicked_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;

                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopModalAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };

            await Navigation.PushModalAsync(scanPage);
        }
    }
}