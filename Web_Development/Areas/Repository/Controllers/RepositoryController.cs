﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AustinsFirstProject.Git_Info_Accessor.Areas.Repository.Controllers
{
    [Area("Repository")]
    [Route("")]
    [Route("Repository")]
    public class RepositoryController : Controller
    {
        private IConfigurationRoot configRoot;
        private string App_Name;
        private string Api_Key;

        public RepositoryController()
        {
            configRoot = Helper.ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            configRoot.GetConnectionString(configRoot.GetSection("environmentVariables")["ENVIRONMENT"]);

            try
            {
                App_Name = configRoot.GetSection("environmentVariables")["App_Name"];
            } catch (Exception ex)
            {
                Library.Logger.Log_Error("[" + this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error getting App_Name from appsetting.json file. Error Msg: " + ex.Message );
            }

            try { 
                Api_Key = configRoot.GetSection("environmentVariables")["GitHub_Api_Key"];
            }
            catch (Exception ex)
            {
                Library.Logger.Log_Error("[" + this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error getting GitHub_Api_Key from appsetting.json file. Error Msg: " + ex.Message);
            }
        }

        [Route("Reload")]
        public void ReRoute()
        {
            string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
            Response.Redirect(baseUrl + "/Repository/Index/github/platform-samples");
        }
        
        [Route("[action]/{owner}/{repo}")]
        public IActionResult Index(string owner, string repo)
        {
            if (String.IsNullOrEmpty(owner) || String.IsNullOrEmpty(repo))
            {
                string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                Response.Redirect(baseUrl);
            }
            string result;
            if (String.IsNullOrEmpty(App_Name)) { App_Name = "";  }
            if (String.IsNullOrEmpty(Api_Key))
            {
                Library.Logger.Log_Error("[" + this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error: Variable 'Api_Key' was empty.");
                result = "";
            }
            else
            {
                result = Github_Api.Api.Rest_Api_V3.Repositories.Get_Basic_Info(App_Name, owner, repo, Api_Key);
            }

            Github_Api.Model.Repository repository = new Github_Api.Model.Repository();
            if (String.IsNullOrEmpty(result)) { }
            else
            {
                try
                {
                    repository = JsonConvert.DeserializeObject<Github_Api.Model.Repository>(result);
                }
                catch (Exception ex)
                {
                    repository = new Github_Api.Model.Repository();
                }
            }
            repository.Api_String = result;

            return View(repository);
        }
        
        [Route("[action]/{owner}/{repo}")]
        public string Commits(string owner, string repo)
        {
            if (String.IsNullOrEmpty(owner) || String.IsNullOrEmpty(repo))
            {
                string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                Response.Redirect(baseUrl);
            }
            string result;
            if (String.IsNullOrEmpty(App_Name)) { App_Name = ""; }
            if (String.IsNullOrEmpty(Api_Key))
            {
                Library.Logger.Log_Error("[" + this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error: Variable 'Api_Key' was empty.");
                result = "";
            }
            else
            {
                result = Github_Api.Api.Rest_Api_V3.Repositories.Get_Commits(App_Name, owner, repo, Api_Key);
            }

            /*List<Github_Api.Model.CommitEvent> commit_event_list = new List<Github_Api.Model.CommitEvent>();

            if (String.IsNullOrEmpty(result)) { }
            else
            {
                try
                {
                    commit_event_list = JsonConvert.DeserializeObject<List<Github_Api.Model.CommitEvent>>(result);
                }
                catch (Exception ex)
                {
                    commit_event_list = new List<Github_Api.Model.CommitEvent>();
                }
            }*/

            return result;
        }

        [Route("[action]/{repo_id:int?}")]
        public IActionResult RepoCommits(int repo_id)
        {
            if (repo_id <= 0)
            {
                string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                Response.Redirect(baseUrl);
            }
            string result;
            if (String.IsNullOrEmpty(App_Name)) { App_Name = ""; }
            if (String.IsNullOrEmpty(Api_Key))
            {
                Library.Logger.Log_Error("[" + this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error: Variable 'Api_Key' was empty.");
                result = "";
            }
            else
            {
                result = Github_Api.Api.Rest_Api_V3.Repositories.Get_Commits(App_Name, repo_id, Api_Key);
            }

            Github_Api.Model.Commits Commits = new Github_Api.Model.Commits();

            if (String.IsNullOrEmpty(result)) { }
            else
            {
                try
                {
                    Commits.Commit_Event_List = JsonConvert.DeserializeObject<List<Github_Api.Model.CommitEvent>>(result);
                    Commits.Repository_Id = repo_id;
                }
                catch (Exception ex)
                {
                    Commits = new Github_Api.Model.Commits();
                }
            }
            return View(Commits);
        }

        [Route("[action]/{repo_id:int?}/{sha}")]
        public string Get_Commit(int repo_id, string sha)
        {
            if (repo_id <= 0)
            {
                string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
                Response.Redirect(baseUrl);
            }
            string result;
            if (String.IsNullOrEmpty(App_Name)) { App_Name = ""; }
            if (String.IsNullOrEmpty(Api_Key))
            {
                Library.Logger.Log_Error("[" + this.GetType().FullName + "." + System.Reflection.MethodBase.GetCurrentMethod().Name + "] Error: Variable 'Api_Key' was empty.");
                result = "";
            }
            else
            {
                result = Github_Api.Api.Rest_Api_V3.Repositories.Get_Commit(App_Name, repo_id, sha, Api_Key);
            }

            return result;
        }
    }
}