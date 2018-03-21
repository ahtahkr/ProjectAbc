using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ProjectAbc.Controllers
{
    [Route("[controller]")]
    public class NewsController : Controller
    {
        // GET: /News
        [HttpGet]
        public IActionResult Get()
        {
            Classes.News.News News 
                = JsonConvert.DeserializeObject<Classes.News.News>(
                        Classes.News.NewsApiOrg.V2.Top_Headlines());
            News.Title = "Headlines";
            return View(News);
        }

        // GET: /News/5
        //[HttpGet("{id}", Name = "Get")]
        //public IActionResult Get(int id)
        //{
        //    return View();
        //}
        
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
