using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Android.OS;
using Newtonsoft.Json;
using SP19.P05.Web.Features.Customers;
using SP19.P05.Web.Features.Shared;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SP19.P05.Mobile.Forms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateUser : ContentPage
    {
       
      public CreateUser()
        { 
         

            InitializeComponent();

            //Console.WriteLine(BindingContext.ToString());
        }






        //Hit post request after the form is submitted
        //prashant basnet 4/4

        async void Post_Clicked(object sender, EventArgs eventArgs)
        {







            //string URL = "http://127.0.0.1:3000/api/Customers";
            HttpClient _client = new HttpClient();



          //  CreateCustomerDto customer = new CreateCustomerDto() { };
            CreateCustomerDto customer = new CreateCustomerDto() { };
            customer.Username = this.username.Text;
            customer.Email = this.email.Text;
            customer.Password = this.password.Text;
            Address AMailingAddress = new Address();
            AMailingAddress.Line1 = this.addressOne.Text;
            AMailingAddress.Line2 = this.addressTwo.Text;
            AMailingAddress.City = this.city.Text;
            AMailingAddress.State = this.state.Text;
            AMailingAddress.ZipCode = this.zipCode.Text;
            customer.MailingAddress = AMailingAddress;




            var client = new HttpClient();
             


            var json = JsonConvert.SerializeObject(customer);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            var result = _client.PostAsync("http://10.0.2.2:3000/api/Customers", content).Result;

            Console.WriteLine("sign up form submitted----------");


            //if the form is valid goes to login page
            //prashant basnet 4/4
            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert("Success", "You posted data to a REST API URL.", "Ok");
                await Navigation.PushModalAsync(new MainPage());
            }
          
            else
                await DisplayAlert("Error", "Please check the data and enter correctly in form.", "Ok");
           


            // string jsonData = @"{""username"" : ""myusername"", ""password"" : ""Password-1234"",""email"" : ""mypassword""}" + customer.MailingAddress;

            //            var content = new StringContent(customer, Encoding.UTF8, "application/json");
            //            client.PostAsync(URL, content);

            // this result string should be something like: "{"token":"rgh2ghgdsfds"}"







            //_client.PostAsync(URL, content).Result;


            //   var response = myHttpClient.PostAsync(uri, formContent).Result;

            // _client.PostAsync(URL, content);


        }

















    }
}