using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ProjectAbc.Controllers
{
    [Route("[controller]")]
    public class StockController : Controller
    {
        // GET: api/Stock
        [HttpGet]
        public IActionResult Get()
        {
            string symbol = "aapl";
            Classes.Stock.Model.Organization organization = new Classes.Stock.Model.Organization();
            organization.Company = JsonConvert.DeserializeObject<Classes.Stock.Model.Company>(IEXTrading.WebApi_V1.Company(symbol));
            if (String.IsNullOrEmpty(organization.Company.CompanyName)) { }
            else
            {
                organization.Book = JsonConvert.DeserializeObject<Classes.Stock.Model.Book>(IEXTrading.WebApi_V1.Book(symbol));

                organization.Stocks = JsonConvert.DeserializeObject<List<Classes.Stock.Model.Stock>>(IEXTrading.WebApi_V1.Chart(symbol, "3m"));
                organization.Stocks_Today = JsonConvert.DeserializeObject<List<Classes.Stock.Model.Stock>>(IEXTrading.WebApi_V1.Chart(symbol, "1d"),
                    new IsoDateTimeConverter { DateTimeFormat = "yyyyMMdd" });
                organization.Logo = JsonConvert.DeserializeObject<Classes.Stock.Model.Logo>(IEXTrading.WebApi_V1.Logo(symbol));
            }
            return View(organization);
        }

        // GET: api/Stock/5
        [HttpGet("{symbol}", Name = "GetStock")]
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
                    organization.Book = JsonConvert.DeserializeObject<Classes.Stock.Model.Book>(IEXTrading.WebApi_V1.Book(symbol));

                    organization.Stocks = JsonConvert.DeserializeObject<List<Classes.Stock.Model.Stock>>(IEXTrading.WebApi_V1.Chart(symbol,"3m"));
                    organization.Stocks_Today = JsonConvert.DeserializeObject<List<Classes.Stock.Model.Stock>>(IEXTrading.WebApi_V1.Chart(symbol, "1d"),
                    new IsoDateTimeConverter { DateTimeFormat = "yyyyMMdd" });
                    organization.Logo = JsonConvert.DeserializeObject<Classes.Stock.Model.Logo>(IEXTrading.WebApi_V1.Logo(symbol));
                }
            }
            return View(organization);
        }
        
        //// POST: api/Stock
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}
        
        //// PUT: api/Stock/5
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
