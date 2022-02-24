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
        [ViewData]
        public string CustomProparty { get; set; }
        [ViewData]
        public string Title { get; set; }
        [ViewData]
        public BookModel Book { get; set; }

        public ViewResult Index()
        {
            CustomProparty = "Indrajith Goswami";

            Title = "Home";

            Book = new BookModel() { Id = 1, Title = "ASP DOT NET"};

            return View();
        }

        public ViewResult AboutUs()
        {
            Title = "AboutUs";
            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "ContactUs";
            return View();
        }

    }
}
