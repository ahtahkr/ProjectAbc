using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace ProjectAbc.Controllers
{
    [Route("[controller]")]
    public class NYTimesController : Controller
    {
        // GET: api/NYTimes
        [HttpGet]
        public IActionResult Get()
        {
            IConfigurationRoot configRoot = Helper.ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            string Api_Key = configRoot.GetSection("environmentVariables")["NYTimes_Api_Key"];

            NYTimes.TopStories topStories = JsonConvert.DeserializeObject<NYTimes.TopStories>(NYTimes.WebApi.V2.TopStories(Api_Key));

            return View(topStories);
        }        
    }
}
