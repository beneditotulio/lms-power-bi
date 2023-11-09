using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Title { get; set; }


        [Display(Name = "Subtítulo")]
        public string Subtitle { get; set; } = "";

        [Required]
        [Display(Name = "CDU")]
        public string CDU { get; set; }

        [Display(Name = "Estante")]
        public int? BookcaseID { get; set; }
        [ForeignKey("BookcaseID")]
        public Bookcase Bookcase { get; set; }

        [Display(Name = "Editora")]
        public int PublisherID { get; set;}
        [ForeignKey("PublisherID")]
        public Publisher Publisher { get; set; }

        [Display(Name = "Idioma")]
        public string LanguageID { get; set; }
        [ForeignKey("LanguageID")]
        public GeneralData Language { get; set; }

        [Display(Name = "Paginação")]
        public int Pagination { get; set; }

        [Display(Name = "Ano de Publicação")]
        public int PublicationYear { get; set; }

        [Display(Name = "Categoria")]
        public string CategoryID { get; set; }
        [ForeignKey("CategoryID")]
        public GeneralData Category { get; set; }

        [Display(Name = "Cópias Disponíveis")]
        public int AvailableCopies  {  get; set; }

        [Display(Name = "País")]
        public string CountryID  { get; set; }
        [ForeignKey("CountryID")]
        public GeneralData Country { get; set; }

        [Display(Name = "Ilustração")]
        public string Illustration { get; set; }
        [NotMapped, Required]
        public string SelectedAuthorIDs { get; set; }

        // Navigation properties for relationships
        public ICollection<BooksAuthors> BooksAuthors { get; set; }
        public ICollection<Copy> Copies { get; set; }
    }


    //public class Books
    //{
    //    [Key]
    //    public string ISBN { get; set; }

    //    [Required]
    //    public string Title { get; set; }

    //    [Required]
    //    public string Subtitle { get; set; }

    //    [Required]
    //    public string CDU { get; set; }

    //    public int? BookcaseID { get; set; }

    //    [ForeignKey("BookcaseID")]
    //    public Bookcase Bookcase { get; set; }

    //    public int PublisherID { get; set; }

    //    [ForeignKey("PublisherID")]
    //    public Publisher Publisher { get; set; }

    //    public string LanguageID { get; set; }

    //    [ForeignKey("LanguageID")]
    //    public GeneralData Language { get; set; }

    //    public int Pagination { get; set; }

    //    public int PublicationYear { get; set; }

    //    public string CategoryID { get; set; }

    //    [ForeignKey("CategoryID")]
    //    public GeneralData Category { get; set; }

    //    public int AvailableCopies { get; set; }

    //    public string CountryID { get; set; }

    //    [ForeignKey("CountryID")]
    //    public GeneralData Country { get; set; }

    //    public string Illustration { get; set; }

    //    // Navigation properties for relationships
    //    public ICollection<BooksAuthors> BooksAuthors { get; set; }
    //    public ICollection<Copy> Copies { get; set; }
    //}


}