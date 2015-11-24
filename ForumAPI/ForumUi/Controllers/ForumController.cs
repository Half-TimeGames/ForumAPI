using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumUi.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ForumUi.Controllers
{
    public class ForumController : Controller
    {
        //TODO: Fix so that we can view number of posts and such inside the thread
        // GET: Forum
        public ActionResult ForumIndex()
        {
            var client = new RestClient();
            client.BaseUrl = new Uri("http://localhost:56513");
            var request = new RestRequest {Resource = "api/Threads"};
            IRestResponse response = client.Execute(request);
            Thread[] threadsArray = JsonConvert.DeserializeObject<Thread[]>(response.Content);

            return View(threadsArray);
        }
    }
}