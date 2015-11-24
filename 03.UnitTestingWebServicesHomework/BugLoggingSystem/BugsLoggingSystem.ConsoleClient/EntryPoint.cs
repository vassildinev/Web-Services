namespace BugLoggingSystem.ConsoleClient
{
    using System;
    using System.Net.Http;

    using Api;
    using Microsoft.Owin.Hosting;
    using System.Collections.Generic;

    public class EntryPoint
    {
        private const string BaseAddress = "http://localhost:9000/";

        public static void Main()
        {
            using (WebApp.Start<Startup>(url: BaseAddress))
            {
                using (var client = new HttpClient())
                {
                    var bugAsText = new Dictionary<string, string>
                    {
                        { "Text", "Test bug" }
                    };

                    var content = new FormUrlEncodedContent(bugAsText);
                    HttpResponseMessage postResponse = client.PostAsync(BaseAddress + "api/bugs", content).Result;
                    HttpResponseMessage getResponse = client.GetAsync(BaseAddress + "api/bugs").Result;
                    Console.WriteLine(postResponse);
                    Console.WriteLine(getResponse);
                    Console.WriteLine();
                    Console.WriteLine(getResponse.Content.ReadAsStringAsync().Result);
                }
            }
        }
    }
}
