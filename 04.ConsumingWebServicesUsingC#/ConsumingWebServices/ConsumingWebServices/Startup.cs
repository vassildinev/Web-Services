namespace ConsumingWebServices
{
    using Newtonsoft.Json;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class Startup
    {
        public static void Main()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage();
                request.Headers.Authorization = new AuthenticationHeaderValue("COmAsfoTl5bHFOoHoKl8uQCo12cA8sl2ytzk2RPu3uRB");
                request.RequestUri = new Uri("https://api.wattpad.com:443/v4/stories");
                var response = client.SendAsync(request).Result;

                string content = response.Content.ReadAsStringAsync().Result;
                var responseObject = JsonConvert.DeserializeObject<Response>(content);
                foreach (var item in responseObject.stories)
                {
                    Console.WriteLine($"{item.id} - {item.title}");
                }
            }
        }
    }
}
