using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("../../TempView/indraTemp");
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
