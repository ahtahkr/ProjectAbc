﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AustinsFirstProject.Library;
using Newtonsoft.Json;

namespace AustinsFirstProject.Git_Web_App.Areas.Home.Controllers
{
    [Area("Home")]
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {

        [Route("")]
        public IActionResult Index()
        {
            Models.Home home = new Models.Home();
            home.Name_Url = SQLiteDB.Database.GetNameUrl();

            //Logger.Log(JsonConvert.SerializeObject(home), "HomeController");

            return View(home);
        }
    }
}