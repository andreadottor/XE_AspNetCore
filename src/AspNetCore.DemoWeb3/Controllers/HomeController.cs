using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCore.DemoWeb3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            this._logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public string Add(int a, int b)
        {
            this._logger.LogInformation($"Method Add: a={a}; b={b};");

            return (a + b).ToString();
        }

        public IActionResult AddJson(string a, string b)
        {
            this._logger.LogInformation($"Method AddJson: a={a}; b={b};");
            
            int intA, intB;
            if(!int.TryParse(a, out intA) || !int.TryParse(b, out intB))
                return BadRequest("Invalid or missing querystring params a,b number!");

            return Json(new {
                // a = a,
                // b = b,
                sum = intA + intB
            });
        }
    }
}
