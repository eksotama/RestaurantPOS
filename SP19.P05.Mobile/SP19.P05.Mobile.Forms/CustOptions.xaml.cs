using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SP19.P05.Mobile.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustOptions : ContentPage
	{
		public CustOptions ()
		{
			InitializeComponent ();
		}
        async void CheckIn_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new CustomerOptions.CheckIn());
        }
        async void Order_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new CustomerOptions.Order());
        }
        async void RequestServer_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new CustomerOptions.RequestServer());
        }
        async void Reserve_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new CustomerOptions.Reserve());
        }
    }
}