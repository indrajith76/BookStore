using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
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
                new BookModel(){Id =1, Title ="MVC", Author ="Rosik", Description="This is the Description for MVC book"},
                new BookModel(){Id =2, Title ="CSharp", Author ="Kobir",Description="This is the Description for CSharp book"},
                new BookModel(){Id =3, Title ="Java", Author ="Kawsik",Description="This is the Description for Java book"},
                new BookModel(){Id =4, Title ="Php", Author ="Sobita",Description="This is the Description for Php book"},
                new BookModel(){Id =5, Title ="Html", Author ="Rokeya",Description="This is the Description for Html book"},
                new BookModel(){Id =6, Title ="Python", Author ="Jhon",Description="This is the Description for Python book"},
            };
        }
    }
}
