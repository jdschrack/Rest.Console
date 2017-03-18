using Newtonsoft.Json;
using Rest.Modal;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Rest
{
    internal class Program
    {
        private static CookieContainer cookies = new CookieContainer();

        private static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://office.sabinoroad.org/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization-Token", "");

            if (Login(client))
                GetCurrentPerson();
            else
                Console.WriteLine("Check your credentials, we were not able to login.");

            Console.ReadLine();
        }

        private static bool Login(HttpClient client)
        {
            bool isLoggedIn = false;
            var handler = new HttpClientHandler();
            client = new HttpClient(handler);
            handler.CookieContainer = cookies;

            var baseAddress = new Uri("httpskis://office.sabinoroad.org/api/");
            client.BaseAddress = baseAddress;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization-Token", "d53L8ThfaymkGZt8MH8tvXTQ");

            var response = new HttpResponseMessage();

            var loginParameters = new LoginParameters();
            loginParameters.Username = "jeremey.schrack";
            loginParameters.Password = "brEchus7";
            loginParameters.Persisted = true;

            var json = JsonConvert.SerializeObject(loginParameters);

            StringContent query = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            response = client.PostAsync("auth/login", query).Result;

            var responseCookies = cookies.GetCookies(baseAddress).Cast<Cookie>();

            if (response.IsSuccessStatusCode)
            {
                isLoggedIn = true;
            }
            return isLoggedIn;
        }

        private static async void GetCurrentPerson()
        {
            var handler = new HttpClientHandler();

            HttpClient client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://office.sabinoroad.org/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization-Token", "d53L8ThfaymkGZt8MH8tvXTQ");

            handler.CookieContainer = cookies;

            var response = await client.GetAsync("groups");
            response = client.GetAsync("People/GetCurrentPerson").Result;

            using (HttpContent content = response.Content)
            {
                var result = content.ReadAsStringAsync();

                var objectResult = JsonConvert.DeserializeObject<Person>(await result);
                Console.WriteLine("Congrats {0}!  You are now logged into {1}", objectResult.FirstName, "sabinoroad.org");
                Console.WriteLine("{0}", objectResult.FullName);
                foreach (var number in objectResult.PhoneNumbers)
                {
                    Console.WriteLine("{0} - {1}", number.NumberFormatted, number.NumberTypeValue.Value);
                }
            }
        }

        public class LoginParameters
        {
            /// <summary>
            /// Gets or sets the username.
            /// </summary>
            /// <value>
            /// The username.
            /// </value>

            public string Username { get; set; }

            /// <summary>
            /// Gets or sets the password.
            /// </summary>
            /// <value>
            /// The password.
            /// </value>

            public string Password { get; set; }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="LoginParameters"/> information is going to be persisted.
            /// </summary>
            /// <value>
            ///   <c>true</c> if persisted; otherwise, <c>false</c>.
            /// </value>

            public bool Persisted { get; set; }
        }
    }
}