using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static GitHubApi.Rest_Api_V3;
using Microsoft.Extensions.Configuration;
using System.IO;
using Newtonsoft.Json;

namespace ProjectAbc.Controllers
{
    [Route("[controller]")]
    public class GitAccessorController : Controller
    {
        // GET: api/GitAccessor
        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        // GET: api/GitAccessor/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("[action]")]
        public IActionResult GitUser(string user)
        {
            IConfigurationRoot configRoot = Helper.ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            configRoot.GetConnectionString(configRoot.GetSection("environmentVariables")["ENVIRONMENT"]);

            string App_Name = configRoot.GetSection("environmentVariables")["App_Name"];
            string Api_Key = configRoot.GetSection("environmentVariables")["GitHub_Api_Key"];
            List<Library.GitAccessor.Model.Repository> repos = JsonConvert.DeserializeObject<List<Library.GitAccessor.Model.Repository>>(Repositories.Get_User_Repositories(user, App_Name, Api_Key));
            return View(repos);
        }

        [HttpGet("[action]/{id}", Name = "RepositoryGet")]
        public IActionResult Repository(int id)
        {
            IConfigurationRoot configRoot = Helper.ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            configRoot.GetConnectionString(configRoot.GetSection("environmentVariables")["ENVIRONMENT"]);

            string App_Name = configRoot.GetSection("environmentVariables")["App_Name"];
            string Api_Key = configRoot.GetSection("environmentVariables")["GitHub_Api_Key"];

            Library.GitAccessor.Model.Repository repo 
                = JsonConvert.DeserializeObject<Library.GitAccessor.Model.Repository>(GitHubApi.Rest_Api_V3.Repositories.Get_Basic_Info(App_Name, id, Api_Key));

            return View(repo);
        }
        
        // POST: api/GitAccessor
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/GitAccessor/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
