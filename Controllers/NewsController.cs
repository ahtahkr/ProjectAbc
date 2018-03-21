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
        [HttpGet("{keyword}", Name = "GetString")]
        public IActionResult Get(string keyword)
        {
            if (String.IsNullOrEmpty(keyword))
            {
                keyword = "America";
            }
            Classes.News.News News
                = JsonConvert.DeserializeObject<Classes.News.News>(
                        Classes.News.NewsApiOrg.V2.Everything("24763003c86c4c439e53ccd7014a1a80", keyword));
            News.Title = keyword;
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
