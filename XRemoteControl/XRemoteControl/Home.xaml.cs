using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace XRemoteControl
{
  
        [XamlCompilation(XamlCompilationOptions.Compile)]
        public partial class Home : ContentPage
        {


            public Home()
            {
                InitializeComponent();



            }
            public async void ShutDown(object sender, EventArgs args)
            {
                try
                {
                    string resp = await Helper.MakeGetRequest("http://192.168.43.4/shutdown.php");
                }
                catch (Exception e)
                {
                    await DisplayAlert("Exception!", e.Message, "cancel");
                }
            }
            public async void Logoff(object sender, EventArgs args)
            {
                try
                {
                    string resp = await Helper.MakeGetRequest("http://192.168.43.4/logoff.php");
                }
                catch (Exception e)
                {
                    await DisplayAlert("Exception!", e.Message, "cancel");
                }
            }
            public async void Restart(object sender, EventArgs args)
            {
                try
                {
                    string resp = await Helper.MakeGetRequest("http://192.168.43.4/restart.php");
                }
                catch (Exception e)
                {
                    await DisplayAlert("Exception!", e.Message, "cancel");
                }
            }
            public async void Procces(object sender, EventArgs args)
            {
                await Navigation.PushModalAsync(new ListProcess());

            }
            public async void Ping(object sender, EventArgs args)
            {
                await Navigation.PushModalAsync(new Ping());
            

            }
            public async void SetVolume(object sender, EventArgs args)
            {
                await Navigation.PushModalAsync(new Volume());

            }



        }
    }

