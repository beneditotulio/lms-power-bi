using SGBWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBWeb.Services
{
    public class BookService
    {
        private readonly LibraryDbContext _context;

        public BookService()
        {
            _context = new LibraryDbContext();
        }
    }
}