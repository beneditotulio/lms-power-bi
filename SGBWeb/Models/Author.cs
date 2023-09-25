using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    [Table("Authors")]
    public class Author
    {
        public int ID { get; set; }
        public string AuthorName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Biography { get; set; } // Author's biography
        public string Website { get; set; }    // Author's website URL
        public string Email { get; set; }      // Author's contact email
        public string Phone { get; set; }      // Author's contact phone number
                                               // Add any other relevant author information properties here
    }

}