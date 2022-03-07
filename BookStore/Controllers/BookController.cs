using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();

            return View(data);
        }

        [Route("book-details/{id}", Name ="bookDetailsRoute")] /* <- compatibile with routing*/
        public async Task<ViewResult> GetBook(int id)
        {
            var date = await _bookRepository.GetBookById(id);

            return View(date);
        }
        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName,authorName);
        }
        public ViewResult AddNewBook(bool isSuccess = false, int bookId = 0) /* <- AddNewBook is an Action Method. */
        {
            ViewBag.Language = new SelectList(new List<string>() { "English", "Bangla", "Hindi" });

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id});
                }
            }

            ViewBag.Language = new SelectList(new List<string>() { "English", "Bangla", "Hindi" });

            ModelState.AddModelError("", "আপনাকে সব শূন্যস্থান পূরণ করতে হবে!");

            return View();
        }
    }
}
