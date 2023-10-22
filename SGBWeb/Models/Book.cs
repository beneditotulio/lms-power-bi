using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    public class Book
    {
        [Key]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Subtítulo")]
        public string Subtitle { get; set; }

        [Required]
        [Display(Name = "CDU")]
        public string CDU { get; set; }

        [Display(Name = "ID da Estante")]
        public int? BookcaseID { get; set; }

        [Display(Name = "Editora")]
        public int PublisherID { get; set;}

        [Display(Name = "Idioma")]
        public string LanguageID { get; set; }

        [Display(Name = "Paginação")]
        public int Pagination { get; set; }

        [Display(Name = "Ano de Publicação")]
        public int PublicationYear { get; set; }

        [Display(Name = "ID da Categoria")]
        public string CategoryID { get; set; }

        [Display(Name = "Cópias Disponíveis")]
        public int AvailableCopies  {  get; set; }

        [Display(Name = "ID do País")]
        public string CountryID  { get; set; }

        [Display(Name = "Ilustração")]
        public string Illustration { get; set; }
    }

}