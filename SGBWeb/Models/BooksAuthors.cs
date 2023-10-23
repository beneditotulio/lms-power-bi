using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    [Table("BooksAuthors")]
    public class BooksAuthors
    {
        [Key]
        public int BookAuthorID { get; set; }

        [Required]
        public string ISBN { get; set; }

        [ForeignKey("ISBN")]
        public Book Book { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("AuthorID")]
        public Author Author { get; set; }
    }
}