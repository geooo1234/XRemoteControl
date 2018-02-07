using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace XRemoteControl 
{
    public static class Helper
    {
        public async static Task<string> MakePostRequest(string url, Dictionary<string, string> postParameters)
        {
            using (var client = new HttpClient())
            {
                var content = new FormUrlEncodedContent(postParameters);

                var response = await client.PostAsync(url, content);

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }

        public async static Task<string> MakeGetRequest(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;
            }
        }
    }
}
