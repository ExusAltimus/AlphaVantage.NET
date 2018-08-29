using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockAnalyzer.Models;

namespace StockAnalyzer.Controllers
{
    public class HomeController : Controller
    {
        //https://www.alphavantage.co/support/#api-key
        private readonly AlphaVantageStockDataQuerier _stockDataQuerier;

        public HomeController(AlphaVantageStockDataQuerier stockDataQuerier)
        {
            _stockDataQuerier = stockDataQuerier;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _stockDataQuerier.GetIntradayTimeSeries("MSFT");
            return View(result);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
