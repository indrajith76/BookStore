using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Tittle = "Indrajith";
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Indrajith";
            
            ViewBag.Data = data;

            ViewBag.Type = new BookModel() { Id = 5, Author = "This is Author" };

            return View();
            //return View("../../TempView/indraTemp");
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
