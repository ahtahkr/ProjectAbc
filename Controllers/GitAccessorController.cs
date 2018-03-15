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

        [Route("[action]/{repo_id:int?}/{sha}")]
        public string Get_Commit(int repo_id, string sha)
        {
            IConfigurationRoot configRoot = Helper.ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            configRoot.GetConnectionString(configRoot.GetSection("environmentVariables")["ENVIRONMENT"]);

            string App_Name = configRoot.GetSection("environmentVariables")["App_Name"];
            string Api_Key = configRoot.GetSection("environmentVariables")["GitHub_Api_Key"];
            string result;
            if (String.IsNullOrEmpty(App_Name)) { App_Name = ""; }
            if (String.IsNullOrEmpty(Api_Key))
            {
                Library.Logger.Log_Error("[" + this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error: Variable 'Api_Key' was empty.");
                result = "";
            }
            else
            {
                result = GitHubApi.Rest_Api_V3.Repositories.Get_Commit(App_Name, repo_id, sha, Api_Key);
            }

            return result;
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

            string result = GitHubApi.Rest_Api_V3.Repositories.Get_Commits(App_Name, id, Api_Key);
            if (String.IsNullOrEmpty(result)) { }
            else
            {
                try
                {
                    repo.CommitEvents = JsonConvert.DeserializeObject<List<Library.GitAccessor.Model.CommitEvent>>(result);
                }
                catch (Exception ex)
                {
                    repo.CommitEvents = new List<Library.GitAccessor.Model.CommitEvent>();
                }
            }

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
