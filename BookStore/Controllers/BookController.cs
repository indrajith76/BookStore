using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        public string GetAllBooks()
        {
            return "All Book";
        }
        public string GetBook(int id)
        {
            return $"Book with ID ={id}";
        }
        public string SearchBooks(string bookName, string author)
        {
            return $"Book Name is {bookName} and Author Name is {author}";
        }
    }
}
