using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XRemoteControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Volume : ContentPage
    {
        public string value;
        public string valuechanged;
        public Volume()
        {
            InitializeComponent();
            changevol("0");
            lab.Text = "0";
            Vol.ValueChanged += HandleValueChanged;
        }
        void HandleValueChanged(object sender, EventArgs e)
        {   // display the value in a label
            lab.Text = Vol.Value.ToString();
            var val = Vol.Value;
            val = val * 655.35;
            valuechanged = val.ToString();
            changevol(valuechanged);
        }

        public async void BackButton(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();

        }
        public async void changevol(string value)
        {
            // myParam.Add(new Param { adress = Adress });
            // var val = Vol.Value;


            // string value = val.ToString();

            if (string.IsNullOrEmpty(value))
            {
                await DisplayAlert("Alert", "Please enter an address!", "OK");
            }
            else
            {
                Dictionary<string, string> postParams = new Dictionary<string, string>
                {
                    {"value",value}
                };


                try
                {
                    string resp = await Helper.MakePostRequest("http://192.168.43.4/changevolume.php", postParams);
                    //response1 = JsonConvert.DeserializeObject<Responses1>(resp);
                    //await DisplayAlert("Question", response.Parameters[0].ImageName, "cancel");
                }
                catch
                {
                    await DisplayAlert("Question", "Exception!", "cancel");

                }

            }
        }

        public async void SetVol(object sender, EventArgs args)
        {
            // myParam.Add(new Param { adress = Adress });
            // var val = Vol.Value;
            value = "0";
            // Mute.IsEnabled = true;
            // if(Mute.IsEnabled)
            //  {
            lab.Text = "0";
            //     value = "1";
            //   }

            // string value = val.ToString();

            if (string.IsNullOrEmpty(value))
            {
                await DisplayAlert("Alert", "Please enter an address!", "OK");
            }
            else
            {
                Dictionary<string, string> postParams = new Dictionary<string, string>
                {
                    {"value",value}
                };


                try
                {
                    string resp = await Helper.MakePostRequest("http://192.168.43.4/volume.php", postParams);
                    //response1 = JsonConvert.DeserializeObject<Responses1>(resp);
                    //await DisplayAlert("Question", response.Parameters[0].ImageName, "cancel");
                }
                catch
                {
                    await DisplayAlert("Question", "Exception!", "cancel");

                }

            }
        }
        public async void SetVol1(object sender, EventArgs args)
        {
            // myParam.Add(new Param { adress = Adress });
            // var val = Vol.Value;
            value = "1";
            // Mute.IsEnabled = true;
            // if(Mute.IsEnabled)
            //  {
            lab.Text = "mute";
            //     value = "1";
            //   }

            // string value = val.ToString();

            if (string.IsNullOrEmpty(value))
            {
                await DisplayAlert("Alert", "Please enter an address!", "OK");
            }
            else
            {
                Dictionary<string, string> postParams = new Dictionary<string, string>
                {
                    {"value",value}
                };


                try
                {
                    string resp = await Helper.MakePostRequest("http://192.168.43.4/volume.php", postParams);
                    //response1 = JsonConvert.DeserializeObject<Responses1>(resp);
                    //await DisplayAlert("Question", response.Parameters[0].ImageName, "cancel");
                }
                catch
                {
                    await DisplayAlert("Question", "Exception!", "cancel");

                }

            }
        }


    }

}
