﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using ForumUi.Models;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft;
using Newtonsoft.Json;

namespace ForumUi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //TODO: Add option to edit users

            var client = new RestClient {BaseUrl = new Uri("http://localhost:56513")};
            string bajs = "bajs_bajs___bajs";
            string[] array = Regex.Split(bajs, "___");

            //client.Authenticator = new HttpBasicAuthenticator("username", "password");
            //Det här är en grej twitter använder sig av som lät väldigt intressant, vet inte hur det fungerar,
            //men verkar som man ska kunna göra en authenticate för att använda sig av ett api.

            //Känns väl onödigt när bara vi använder API:t

            var request = new RestRequest {Resource = "api/Users"};

            IRestResponse response = client.Execute(request);
            var userList = JsonConvert.DeserializeObject<List<User>>(response.Content);
            /*var userlist = userList.ToList();*/ //Behövs säkert inte
            return View(userList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}