using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace GithubDashboard.Controllers
{
    public class HomeController : Controller
    {
        // setup the HttpClient here to use across all actions
        static HttpClient client = GetHttpClient();

        public ActionResult Index()
        {
            // make the call to the Events API to get the 30 most recent events
            HttpResponseMessage response = client.GetAsync("events").Result;
            System.Diagnostics.Debug.WriteLine(response);

            if (response.IsSuccessStatusCode)
            {
                // create Json serialize/deserialize settings so we can skip null values from Github
                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;

                var json = response.Content.ReadAsAsync<dynamic>().Result;
                var events = JsonConvert.DeserializeObject<IEnumerable<Models.Event>>(json.ToString(), settings);

                return View(events);
            }
            else
            {
                // problem with call to github; create some exception/error here to pass to the view for display
                ViewBag.Error = "Failed to retrieve Events from Github."; // TODO fix the error handling here!!!
                return View();
            }
        }

        public ActionResult EventDetails(string owner, string id)
        {
            // make the call to the Events API to get the 30 most recent events for the given user(owner)
            HttpResponseMessage response = client.GetAsync("users/" + owner + "/events/public").Result;
            if (response.IsSuccessStatusCode)
            {
                // create Json serialize/deserialize settings so we can skip null values from Github
                var settings = new JsonSerializerSettings();
                settings.NullValueHandling = NullValueHandling.Ignore;
                settings.MissingMemberHandling = MissingMemberHandling.Ignore;

                var json = response.Content.ReadAsAsync<dynamic>().Result;
                var userEvents = JsonConvert.DeserializeObject<IEnumerable<Models.Event>>(json.ToString(), settings);

                // loop through the userEvents to find the one with the requested ID
                foreach (Models.Event item in userEvents)
                {
                    if (item.id == id)
                    {
                        // found the event requested; return it
                        return View(item);
                    }
                }

                // if this point is reached, then the requested user event could not be found (possibly deleted by user?)
                return View();
            }
            else
            {
                // problem with call to github; create some exception/error here to pass to the view for display
                ViewBag.Error = "Failed to retrieve Events from Github."; // TODO fix the error handling here!!!
                return View();
            }
        }

        private static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            // need to add the "User-Agent" header to make Github happy
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2;)");
            return client;
        }
    }
}