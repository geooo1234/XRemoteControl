using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XRemoteControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ping : ContentPage
    {


        ObservableCollection<Param> myParam = new ObservableCollection<Param>();
        public Ping()
        {
            InitializeComponent();
            ParamView.ItemsSource = myParam;

        }
        public async void BackButton(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();

        }

        public async void Send(object sender, EventArgs args)
        {
            // myParam.Add(new Param { adress = Adress });
            string s = TextEntry.Text;
            label1.IsVisible = false;

            if (string.IsNullOrEmpty(s))
            {
                await DisplayAlert("Alert", "Please enter an address!", "OK");
            }
            else
            {
                Responses1 response1 = null;
                //  var q = (Parameter)e.SelectedItem;
                Dictionary<string, string> postParams = new Dictionary<string, string>
                {
                    {"adress",s}
                };


                try
                {
                    string resp = await Helper.MakePostRequest("http://192.168.43.4/ping.php", postParams);
                    response1 = JsonConvert.DeserializeObject<Responses1>(resp);
                    //await DisplayAlert("Question", response.Parameters[0].ImageName, "cancel");
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Question", ex.Message, "cancel");

                }
                if (response1 != null)
                {
                    if (response1.Pings != null)
                    {
                        if (response1.Pings.Ip.Equals("0") && response1.Pings.Sent.Equals("0"))
                        {
                            var t = (Param)ParamView.SelectedItem;
                            myParam.Remove(t);
                            label1.IsVisible = true;


                        }
                        else
                        {
                            myParam.Add(new Param { ip = response1.Pings.Ip, sent = response1.Pings.Sent, received = response1.Pings.Received, lost = response1.Pings.Lost, minimum = response1.Pings.Minimum, maximum = response1.Pings.Maximum, average = response1.Pings.Average });
                            var q = (Param)ParamView.SelectedItem;
                            myParam.Remove(q);
                        }
                        //   stk.IsVisible = true;
                        // ParametersView.IsVisible = false;

                    }
                    else
                    {
                        //Message.IsVisible = true;
                    }

                }


            }
        }
    }
}
