using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ProjectAbc.Controllers
{
    [Route("[controller]")]
    public class NewsController : Controller
    {
        // GET: /News
        [HttpGet]
        public IActionResult Get()
        {
            IConfigurationRoot configRoot = Helper.ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            string Api_Key = configRoot.GetSection("environmentVariables")["News_Api_Key"];

            Classes.News.News News 
                = JsonConvert.DeserializeObject<Classes.News.News>(
                        Classes.News.NewsApiOrg.V2.Top_Headlines(Api_Key));
            News.Title = "Headlines";
            return View(News);
        }

        // GET: /News/5
        [HttpGet("{id}", Name = "GetString")]
        public IActionResult Get(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                id = "America";
            }

            IConfigurationRoot configRoot = Helper.ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            string Api_Key = configRoot.GetSection("environmentVariables")["News_Api_Key"];
            Classes.News.News News;

            if (id[0].Equals('$'))
            {
                id = id.Substring(1, id.Length - 1);
                News
                    = JsonConvert.DeserializeObject<Classes.News.News>(
                            Classes.News.NewsApiOrg.V2.Everything_Sources(Api_Key, id));
            }
            else
            {
                News
                    = JsonConvert.DeserializeObject<Classes.News.News>(
                            Classes.News.NewsApiOrg.V2.Everything(Api_Key, id));
            }
            News.Title = id;
            return View(News);
        }
        
        // POST: api/News
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}
        
        // PUT: api/News/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        
        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
