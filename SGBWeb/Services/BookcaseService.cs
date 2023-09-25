using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBWeb.Services
{
    public class BookcaseService
    {
        private readonly LibraryDbContext _dbContext;

        public BookcaseService()
        {
            _dbContext = new LibraryDbContext();
        }

        // Create a new Bookcase record
        public void CreateBookcase(Bookcase bookcase)
        {
            _dbContext.Bookcases.Add(bookcase);
            _dbContext.SaveChanges();
        }

        // Retrieve a Bookcase record by ID
        public Bookcase GetBookcaseById(int id)
        {
            return _dbContext.Bookcases.FirstOrDefault(b => b.BookcaseID == id);
        }

        // Retrieve all Bookcase records
        public List<Bookcase> GetAllBookcases()
        {
            return _dbContext.Bookcases.ToList();
        }

        // Update an existing Bookcase record
        public void UpdateBookcase(Bookcase bookcase)
        {
            //_dbContext.Bookcases.Update(bookcase);
            _dbContext.SaveChanges();
        }

        // Delete a Bookcase record by ID
        public void DeleteBookcase(int id)
        {
            var bookcase = _dbContext.Bookcases.FirstOrDefault(b => b.BookcaseID == id);
            if (bookcase != null)
            {
                _dbContext.Bookcases.Remove(bookcase);
                _dbContext.SaveChanges();
            }
        }
    }

}