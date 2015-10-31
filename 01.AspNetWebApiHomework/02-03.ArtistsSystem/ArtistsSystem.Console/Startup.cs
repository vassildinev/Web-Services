namespace ArtistsSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    using Microsoft.Owin.Hosting;
    using Models.Places;
    using Services;
    using Models.People;

    public class Startup
    {
        private const string JsonContentType = "application/json";
        private const string BaseAddress = "http://localhost:19007";

        public static void Main()
        {
            using (WebApp.Start<ArtistsSystemStartup>(url: BaseAddress))
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(BaseAddress)
                };

                client
                    .DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue(JsonContentType));

                string countriesRoute = "api/countries";
                string singersRoute = "api/singers";

                HttpResponseMessage countriesResponse = client.GetAsync(countriesRoute).Result;
                HttpResponseMessage singersResponse = client.GetAsync(singersRoute).Result;

                Console.WriteLine(new string(c: '=', count: 30));
                if (countriesResponse.IsSuccessStatusCode)
                {
                    ICollection<Country> countries = countriesResponse
                        .Content
                        .ReadAsAsync<ICollection<Country>>()
                        .Result;

                    foreach (var c in countries)
                    {
                        Console.WriteLine($"{c.Id} - {c.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"{countriesResponse.StatusCode} ({countriesResponse.ReasonPhrase})");
                }

                Console.WriteLine(Environment.NewLine + new string(c: '=', count: 30));

                if (singersResponse.IsSuccessStatusCode)
                {
                    ICollection<Singer> singers = singersResponse
                        .Content
                        .ReadAsAsync<ICollection<Singer>>()
                        .Result;

                    foreach (var s in singers)
                    {
                        Console.WriteLine($"{s.FirstName} {s.LastName}, Age: {s.Age}");
                    }
                }
                else
                {
                    Console.WriteLine($"{singersResponse.StatusCode} ({singersResponse.ReasonPhrase})");
                }
            }
        }
    }
}
