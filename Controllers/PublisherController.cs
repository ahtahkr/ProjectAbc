using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ProjectAbc.Controllers
{
    [Route("[controller]")]
    public class PublisherController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            IConfigurationRoot configRoot = Helper.ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            string Api_Key = configRoot.GetSection("environmentVariables")["News_Api_Key"];

            Classes.News.Publisher Publisher 
                = JsonConvert.DeserializeObject<Classes.News.Publisher>(
                        ProjectAbc.Classes.News.NewsApiOrg.V2.Sources(Api_Key)
                  );
            return View(Publisher);
        }
    }
}
