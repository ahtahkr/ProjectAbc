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
        // GET: api/Publisher
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

        // GET: api/Publisher/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        
        //// POST: api/Publisher
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}
        
        //// PUT: api/Publisher/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}
        
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
