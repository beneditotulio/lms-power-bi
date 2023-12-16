using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGBWeb.Data
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer<LibraryDbContext>(null);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<GeneralData> GeneralDatas { get; set; }
        public DbSet<Bookcase> Bookcases { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<BooksAuthors> BooksAuthors { get; set; }
        public DbSet<Copy> Copies { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }
    }
}