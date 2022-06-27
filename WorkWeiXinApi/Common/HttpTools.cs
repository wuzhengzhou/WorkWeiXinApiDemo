namespace WorkWeiXinApi
{
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.IO;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using System.Text;
    public class HttpTools
    {
        public static async Task<string> DoGet(string url)
        {
            string responseBody = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Method", "Get");
                httpClient.DefaultRequestHeaders.Add("KeepAlive", "false");
                httpClient.DefaultRequestHeaders.Add("UserAgent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.11 (KHTML, like Gecko) Chrome/23.0.1271.95 Safari/537.11");

                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            return responseBody;
        }

        public static async Task<T> DoPost<T>(string Url, object message) where T : new()
        {
            var res = new T();
            string jsonContent = JsonConvert.SerializeObject(message);
            string responseBody = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                httpClient.DefaultRequestHeaders.Add("Method", "Post");
                HttpResponseMessage response = await httpClient.PostAsync(Url, content);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
                res = (T)JsonConvert.DeserializeObject<T>(responseBody);
            }
            return res;
        }
    }
}
