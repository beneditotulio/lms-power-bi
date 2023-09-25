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
    }
}