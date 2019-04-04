using Newtonsoft.Json;
using SP19.P05.Web.Features.Customers;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
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
            await Navigation.PushModalAsync(new QRpage());
        }
        async void OnTapGestureRecognizerTapped(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new CreateUser());
        }




        //Hit post request after the form is submitted
        //prashant basnet 4/4
        async void Post_Clicked(object sender, EventArgs eventArgs)
        {


 


 

            //string URL = "http://127.0.0.1:3000/api/Authentication";
            HttpClient _client = new HttpClient();


           
            CreateCustomerDto customer = new CreateCustomerDto() { };
            customer.Username = this.username.Text;
         
            customer.Password = this.password.Text;
             



 

            var client = new HttpClient();
            // client.BaseAddress = new Uri("http://127.0.0.1:3000/api/Authentication");


            var json = JsonConvert.SerializeObject(customer);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
           
               
          var result=   _client.PostAsync("http://10.0.2.2:3000/api/Authentication", content).Result;

          Console.WriteLine("login form submitted----------");



            //if the form is valid goes to qrpage
            //prashant basnet 4/4
            if (result.IsSuccessStatusCode)
          {
              await DisplayAlert("Success", "You posted data to a REST API URL.", "Ok");
              await Navigation.PushModalAsync(new QRpage());
            }
            
            //else will display failure and stay on the samepage
           else
                await DisplayAlert("Error", "Login  failure.", "Ok");
           

            


        }




    }
}
