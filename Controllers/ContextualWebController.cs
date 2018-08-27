using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContextualWeb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ProjectAbc.Controllers
{
    [Route("[controller]")]
    public class ContextualWebController : Controller
    {
        private string SearchString = "Microsoft";

        [HttpGet]
        public IActionResult Get()
        {
            NewsSearch newsSearch = GetNewsSearch();
            return View(newsSearch);
        }

        [HttpGet("{searchstring}", Name = "GetContextualWeb")]
        public IActionResult Get(string searchstring)
        {
            SearchString = searchstring;
            NewsSearch newsSearch = GetNewsSearch();
            return View(newsSearch);
        }

        private NewsSearch GetNewsSearch()
        {
            return JsonConvert.DeserializeObject<NewsSearch>(WebApi.NewsSearchRequest(SearchString));
        }
    }
}
