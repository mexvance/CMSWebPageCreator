﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CMSWebPageCreator.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using RestSharp;

namespace CMSWebPageCreator.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //var request1 = GetReleases("https://theysaidso.com/api");

            var client = new RestClient(" http://quotes.rest/");
            var request = new RestRequest("qod", Method.GET);

            IRestResponse response = client.Execute(request);
            var content = response.Content;
            var jObject = JObject.Parse(content);
            /*var myQuote = (string)jObject["contents"]["quotes"][0]["quote"];
            var myQuoteAuthor = (string)jObject["contents"]["quotes"][0]["author"];
            ViewData["quote"] = myQuote;
            ViewData["author"] = myQuoteAuthor;*/
            return View();

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string GetReleases(string url)
        {
            var client = new WebClient();
            //client.Headers.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);

            var response = client.DownloadString(url);

            return response;
        }
    }
}
