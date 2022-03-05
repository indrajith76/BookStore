using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow
            };

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;

        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel() 
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookDetails;
            }
            return null;
        }
        public List<BookModel> SearchBook(string tittle, string authorname)
        {
            return DataSource().Where(x => x.Title.Contains(tittle) || x.Author.Contains(authorname)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id =1, Title ="MVC", Author ="Rosik", Description="This is the Description for MVC book", Category="Framework", Language="English", TotalPages=154},
                new BookModel(){Id =2, Title ="CSharp", Author ="Kobir",Description="This is the Description for CSharp book",Category="Programming", Language="Bangla", TotalPages=164},
                new BookModel(){Id =3, Title ="Java", Author ="Kawsik",Description="This is the Description for Java book",Category="Concept", Language="German", TotalPages=164},
                new BookModel(){Id =4, Title ="Php", Author ="Sobita",Description="This is the Description for Php book",Category="DataFlow", Language="Hindi", TotalPages=134},
                new BookModel(){Id =5, Title ="Html", Author ="Rokeya",Description="This is the Description for Html book",Category="WebDesign", Language="Chinese", TotalPages=124},
                new BookModel(){Id =6, Title ="Python", Author ="Jhon",Description="This is the Description for Python book",Category="MachineLearning", Language="English", TotalPages=184},
            };
        }
    }
}
