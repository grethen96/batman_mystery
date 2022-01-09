using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BatmanTask.Models;
using BatmanTask.Services;

namespace BatmanTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HelpService service = new HelpService();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int countOfNumbers, int startNumber)
        {
            if (countOfNumbers > 0)
            {
                try
                {
                    int result = service.CalculateSum(countOfNumbers, startNumber);                    
                    ViewBag.result = string.Format("The mystery solution is: {0} ", result);                       
                  
                }
                catch (Exception e)
                {
                    _logger.LogInformation(e.Message);
                    ViewBag.result = "There was an error while performing the request.";                  
                }
            }
            else
            {
                ViewBag.result = "The count of numbers cannot be less than 1!";               
            }
            return View();
        }      
    }
}
