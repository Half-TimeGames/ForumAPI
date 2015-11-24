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
    public class ThreadController : Controller
    {
        //TODO: Fix so that we can view number of posts and such inside the thread
        // GET: Forum
        public ActionResult Index(int id)
        {
            var client = new RestClient { BaseUrl = new Uri("http://localhost:56513") };
            var threadRequest = new RestRequest { Resource = "api/Threads" };
            IRestResponse response = client.Execute(threadRequest);
            var tempThreadList = JsonConvert.DeserializeObject<List<Thread>>(response.Content);

            var threadList = tempThreadList.Where(thread => thread.Topic.Id == id).ToList();

            return View(threadList);
        }

        public ActionResult Posts(int id)
        {
            var client = new RestClient { BaseUrl = new Uri("http://localhost:56513") };
            var threadRequest = new RestRequest { Resource = "api/Threads" };
            IRestResponse response = client.Execute(threadRequest);
            var tempThreadList = JsonConvert.DeserializeObject<List<Thread>>(response.Content);

            var threadList = new List<Post>();

            foreach (var thread in tempThreadList)
            {
                if (thread.Id == id)
                    threadList.AddRange(thread.Posts);
            }

            return View(threadList);
        }
    }
}