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
	public partial class CreateUser : ContentPage
	{
		public CreateUser ()
		{
			InitializeComponent ();
		}
        async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new Page1());
        }
    }
}