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
	public partial class ManagerOption : ContentPage
	{
		public ManagerOption ()
		{
			InitializeComponent ();
		}
        async void AdjustTables_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new MgrOptions.AdjustTables());
        }
        async void AdjustEmployees_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new MgrOptions.AdjustEmployees());
        }
        async void AdjustMenu_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new MgrOptions.AdjustMenu());
        }
    }
}