using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGBWeb.Services
{
    public class AuthorService
    {
        private readonly LibraryDbContext _context;

        public AuthorService()
        {
            _context = new LibraryDbContext();
        }

        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.Find(id);
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }
    }

}