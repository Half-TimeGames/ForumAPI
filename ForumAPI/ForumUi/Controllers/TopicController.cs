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
    public class TopicController : Controller
    {
        // GET: Topic
        public ActionResult Index()
        {
            var client = new RestClient { BaseUrl = new Uri("http://localhost:56513") };
            var threadRequest = new RestRequest { Resource = "api/Threads" };
            IRestResponse response = client.Execute(threadRequest);
            var threadList = JsonConvert.DeserializeObject<List<Thread>>(response.Content);

            var topicList = new List<Topic>();

            foreach (var thread in threadList.TakeWhile(thread => !topicList.Contains(thread.Topic)))
            {
                topicList.Add(thread.Topic);
            }

            return View(topicList);

        }
    }
}
