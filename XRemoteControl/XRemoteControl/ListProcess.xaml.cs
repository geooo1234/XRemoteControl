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
    public partial class ListProcess : ContentPage
    {
        public string NameImage;
        ObservableCollection<Parameter> myParameters = new ObservableCollection<Parameter>();
        public ListProcess()
        {
            InitializeComponent();
            ParametersView.ItemsSource = myParameters;

        }

        public void AppLoaded(object sender, EventArgs e)
        {
            Select("notepad++.exe");
            Select("winword.exe");
            Select("wordpad.exe");
            //Select("excel.exe");


            // myParameters.Add(new Parameter { imagename = "notepad++.exe" });
            //  myParameters.Add(new Parameter { imaSgename = "cmd.exe" });
            //  myParameters.Add(new Parameter { imagename = "explorer.exe" });

        }
        public async void BackButton(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();

        }
        public async void Select(string nume)
        {


            Responses response = null;
            //  var q = (Parameter)e.SelectedItem;
            Dictionary<string, string> postParams = new Dictionary<string, string>
            {
                { "nume",nume }
            };


            try
            {
                string resp = await Helper.MakePostRequest("http://192.168.43.4/tasklist.php", postParams);
                response = JsonConvert.DeserializeObject<Responses>(resp);
                //await DisplayAlert("Question", response.Parameters[0].ImageName, "cancel");



            }
            catch
            {
                await DisplayAlert("Question", "Exception!", "cancel");

            }
            if (response != null)
            {
                if (response.Parameters != null)
                {
                    foreach (var t in response.Parameters)
                    {
                        if (t.ImageName.Equals("No") && t.PID.Equals("tasks"))
                        {

                            myParameters.Add(new Parameter { imagename = nume, pid = "No tasks are running which match the specified criteria." });
                        }
                        else
                        {
                            myParameters.Add(new Parameter { imagename = t.ImageName, pid = t.PID, sessionname = t.SessionName, sessionnumber = t.SessionNumber, status = t.Status, memusage = t.MemUsage, username = t.UserName, cputime = t.CPUtime });
                        }
                        //   stk.IsVisible = true;
                        // ParametersView.IsVisible = false;
                    }
                }
                else
                {
                    //Message.IsVisible = true;
                }


            }
        }
        public async void StartStop(object sender, SelectedItemChangedEventArgs e)
        {
            Responses response = null;
            ParametersView.ItemsSource = myParameters;
            //  var myInput = "questionid";
            var q = (Parameter)e.SelectedItem;
            NameImage = q.imagename;


            Dictionary<string, string> postParams = new Dictionary<string, string>
            {
                { "nume",NameImage }
            };
            var answer = await DisplayAlert("Question", "What do you want with this process?", "Start", "Stop");
            if (answer == true)
            {

                string resp = await Helper.MakePostRequest("http://192.168.43.4/start.php", postParams);
                response = JsonConvert.DeserializeObject<Responses>(resp);
                Select(q.imagename);
                myParameters.Remove(q);






            }
            else
            {

                string resp = await Helper.MakePostRequest("http://192.168.43.4/stop.php", postParams);
                response = JsonConvert.DeserializeObject<Responses>(resp);
                Select(q.imagename);
                myParameters.Remove(q);


            }
        }
    }
}
