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
    [Route("/CompanyNews")]
    public class CompanyNewsController : Controller
    {
        // GET: api/CompanyNews
        [HttpGet]
        public IActionResult Get()
        {
            string symbol = "aapl";
            Classes.Stock.Model.Organization organization = new Classes.Stock.Model.Organization();

            if (String.IsNullOrEmpty(symbol)) { }
            else
            {
                organization.Company = JsonConvert.DeserializeObject<Classes.Stock.Model.Company>(IEXTrading.WebApi_V1.Company(symbol));
                if (String.IsNullOrEmpty(organization.Company.CompanyName)) { }
                else
                {
                    //organization.Book = JsonConvert.DeserializeObject<Classes.Stock.Model.Book>(IEXTrading.WebApi_V1.Book(symbol));
                    string[] peers = JsonConvert.DeserializeObject<string[]>(IEXTrading.WebApi_V1.Peers(symbol));
                    string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

                    for (int a = 0; a < peers.Length; a++)
                    {
                        Classes.Stock.Model.Peers Peers = new Classes.Stock.Model.Peers();
                        Peers.Name = peers[a];
                        Peers.Url = baseUrl + "/Stock/" + peers[a];

                        organization.Peers.Add(Peers);
                    }

                    IConfigurationRoot configRoot = Helper.ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
                    configRoot.GetConnectionString(configRoot.GetSection("environmentVariables")["ENVIRONMENT"]);
                    string Api_Key = configRoot.GetSection("environmentVariables")["News_Api_Key"];

                    symbol = symbol.ToUpper();

                    try
                    {
                        organization.News = JsonConvert.DeserializeObject<NewsApiOrg.Everything>(NewsApiOrg.Api.V2.Everything_Period(Api_Key, symbol, DateTime.Now.AddYears(-1), DateTime.Now));
                    }
                    catch { }
                    /*
                    try
                    {
                        organization.Stocks = JsonConvert.DeserializeObject<List<Classes.Stock.Model.Stock>>(IEXTrading.WebApi_V1.Chart(symbol, "3m"));
                    }
                    catch (Exception ex) { }

                    try
                    {
                        organization.Stocks_Today = JsonConvert.DeserializeObject<List<Classes.Stock.Model.Stock>>(IEXTrading.WebApi_V1.Chart(symbol, "1d"),
                        new IsoDateTimeConverter { DateTimeFormat = "yyyyMMdd" });
                    }
                    catch (Exception ex) { }
                    */
                    try
                    {
                        organization.Logo = JsonConvert.DeserializeObject<Classes.Stock.Model.Logo>(IEXTrading.WebApi_V1.Logo(symbol));
                    }
                    catch { }
                }
            }
            return View(organization);
        }

        // GET: CompanyNews/5
        [HttpGet("{symbol}", Name = "Get_CompanyNews")]
        public IActionResult Get(string symbol)
        {
            Classes.Stock.Model.Organization organization = new Classes.Stock.Model.Organization();

            if (String.IsNullOrEmpty(symbol)) { }
            else
            {
                organization.Company = JsonConvert.DeserializeObject<Classes.Stock.Model.Company>(IEXTrading.WebApi_V1.Company(symbol));
                if (String.IsNullOrEmpty(organization.Company.CompanyName)) { }
                else
                {
                    //organization.Book = JsonConvert.DeserializeObject<Classes.Stock.Model.Book>(IEXTrading.WebApi_V1.Book(symbol));
                    string[] peers = JsonConvert.DeserializeObject<string[]>(IEXTrading.WebApi_V1.Peers(symbol));
                    string baseUrl = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";

                    for (int a = 0; a < peers.Length; a++)
                    {
                        Classes.Stock.Model.Peers Peers = new Classes.Stock.Model.Peers();
                        Peers.Name = peers[a];
                        Peers.Url = baseUrl + "/Stock/" + peers[a];

                        organization.Peers.Add(Peers);
                    }

                    IConfigurationRoot configRoot = Helper.ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
                    configRoot.GetConnectionString(configRoot.GetSection("environmentVariables")["ENVIRONMENT"]);
                    string Api_Key = configRoot.GetSection("environmentVariables")["News_Api_Key"];

                    symbol = symbol.ToUpper();

                    try
                    {
                        organization.News = JsonConvert.DeserializeObject<NewsApiOrg.Everything>(NewsApiOrg.Api.V2.Everything_Period(Api_Key, symbol,DateTime.Now.AddYears(-1), DateTime.Now));
                    }
                    catch { }
                    /*
                    try
                    {
                        organization.Stocks = JsonConvert.DeserializeObject<List<Classes.Stock.Model.Stock>>(IEXTrading.WebApi_V1.Chart(symbol, "3m"));
                    }
                    catch (Exception ex) { }

                    try
                    {
                        organization.Stocks_Today = JsonConvert.DeserializeObject<List<Classes.Stock.Model.Stock>>(IEXTrading.WebApi_V1.Chart(symbol, "1d"),
                        new IsoDateTimeConverter { DateTimeFormat = "yyyyMMdd" });
                    }
                    catch (Exception ex) { }
                    */
                    try
                    {
                        organization.Logo = JsonConvert.DeserializeObject<Classes.Stock.Model.Logo>(IEXTrading.WebApi_V1.Logo(symbol));
                    }
                    catch { }
                }
            }
            return View(organization);
        }
        
        // POST: api/CompanyNews
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/CompanyNews/5
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
