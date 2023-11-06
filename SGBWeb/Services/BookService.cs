using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SGBWeb.Services
{
    public class BookService
    {
        private readonly LibraryDbContext _context;

        public BookService()
        {
            _context = new LibraryDbContext();
        }
        public List<Book> GetAllBooks()
        {
            return _context
                .Books
                .Include(b => b.Bookcase)
                .Include(b => b.Category)
                .Include(b => b.Country)
                .Include(b => b.Language)
                .Include(b => b.Publisher)
                .ToList();
        }
        public bool CreateBook(Book book)
        {
            bool result = false;
            _context.Books.Add(book);
            _context.SaveChanges();
            result = true;
            return result;
        }
        public void CreateBookAuthors(BooksAuthors booksAuthors)
        {
            _context.BooksAuthors.Add(booksAuthors);
            _context.SaveChanges();
        }
        // Function that takes a string series and returns an array of numbers
        public string[] RemoveAuthorsIds(string series)
        {
            // Split the series by comma
            string[] parts = series.Split(',');

            // Filter out the parts that are numbers
            //string[] numbers = parts.Where(part => int.TryParse(part, out _)).ToArray();

            // Return the numbers array
            return parts;
        }
    }
}