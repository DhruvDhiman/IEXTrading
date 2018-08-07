using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Infrastructure.IEXTradingHandler;
using TradingData.Models;
using TradingData.DataAccess;
using TradingData.Models.ViewModel;

namespace TradingData.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext dbContext;

        public HomeController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            List<Company> companies = null;
            return View(companies);
        }

        /****
         * The Symbols action calls the GetSymbols method that returns a list of Companies.
         * This list of Companies is passed to the Symbols View.
        ****/
        public IActionResult Symbols()
        {
            //Set ViewBag variable first
            ViewBag.dbSucessComp = 0;
            IEXHandler webHandler = new IEXHandler();
            List<Company> companies = webHandler.GetSymbols();

            //Save comapnies in a session var
            HttpContext.Session.SetString("Companies", JsonConvert.SerializeObject(companies));

            return View(companies);
        }

        /****
         * The Quote action calls the GetQuote method that returns a Quote for the passed symbol.
         * A ViewModel CompaniesQuote containing the list of companies and the Quote is passed to the Quote View.
        ****/
        public IActionResult Chart(string symbol)
        {
            //Set ViewBag variable first
            ViewBag.dbSuccessChart = 0;
            List<Chart> Charts = new List<Chart>();
            if(symbol != null)
            {
                IEXHandler webHandler = new IEXHandler();
                Charts = webHandler.GetChart(symbol);
                Charts = Charts.OrderBy(c => c.date).ToList(); //Make sure the data is in ascending order of date.
            }

            //Save Charts in a session variable
            HttpContext.Session.SetString("Charts", JsonConvert.SerializeObject(Charts));

            return View(new CompaniesCharts(dbContext.Companies.ToList(), Charts));
        }

        /****
         * The Refresh action calls the ClearTables method to delete records from a or all tables.
         * Count of current records for each table is passed to the Refresh View.
        ****/
        public IActionResult Refresh(string tableToDel)
        {
            ClearTables(tableToDel);
            Dictionary<string, int> tableCount = new Dictionary<string, int>();
            tableCount.Add("Companies", dbContext.Companies.Count());
            tableCount.Add("Charts", dbContext.Charts.Count());
            return View(tableCount);
        }

        /****
         * Saves the Symbols in database.
        ****/
        public IActionResult PopulateSymbols()
        {
            //IEXHandler webHandler = new IEXHandler();
            //List<Company> companies = webHandler.GetSymbols();
            List<Company> companies = JsonConvert.DeserializeObject<List<Company>>(HttpContext.Session.GetString("Companies"));
            foreach(Company company in companies)
            {
                //Database will give PK constraint violation error when trying to insert record with existing PK.
                //Uncomment below lines to avoid such errors. 
                if (dbContext.Companies.Where(c => c.symbol.Equals(company.symbol)).Count() == 0)
                {
                    dbContext.Companies.Add(company);
                }
            }
            dbContext.SaveChanges();
            ViewBag.dbSucessComp = 1;
            return View("Symbols", companies);
        }

        /****
         * Saves the charts in database.
        ****/
        public IActionResult SaveCharts(string symbol)
        {
            //IEXHandler webHandler = new IEXHandler();
            //List<Chart> Charts = webHandler.GetChart(symbol);
            List<Chart> Charts = JsonConvert.DeserializeObject<List<Chart>>(HttpContext.Session.GetString("Charts"));
            foreach (Chart chart in Charts)
            {
                if (dbContext.Charts.Where(c => c.date.Equals(chart.date)).Count() == 0)
                {
                    dbContext.Charts.Add(chart);
                }
            }
            
            dbContext.SaveChanges();
            ViewBag.dbSuccessChart = 1;
            return View("Chart", new CompaniesCharts(dbContext.Companies.ToList(), Charts));
        }

        /****
         * Deletes the records from tables.
        ****/
        public void ClearTables(string tableToDel)
        {
            if ("all".Equals(tableToDel))
            {
                dbContext.Charts.RemoveRange(dbContext.Charts);
                dbContext.Companies.RemoveRange(dbContext.Companies);
            }
            else if ("Companies".Equals(tableToDel))
            {
                //Running below code may give FK constraint violation error. 
                //Uncomment line below to avoid such errors.
                dbContext.Companies.RemoveRange(dbContext.Companies
                                                         .Where(c => c.charts.Count == 0)
                                                                      );
            }
            else if ("Charts".Equals(tableToDel))
            {
                dbContext.Charts.RemoveRange(dbContext.Charts);
            }
            dbContext.SaveChanges();
        }

    }
}
