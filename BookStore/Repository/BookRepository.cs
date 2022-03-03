﻿using BookStore.Data;
using BookStore.Models;
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

        public int AddNewBook(BookModel model)
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

            _context.Books.Add(newBook);
            _context.SaveChanges();

            return newBook.Id;

        }

        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
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
