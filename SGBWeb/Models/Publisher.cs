using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    [Table("Publishers")]
    public class Publisher
    {
        [Key]
        public int PublisherID { get; set; }

        [Required]
        [Display(Name = "Nome da Editora")]
        public string PublisherName { get; set; }

        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Display(Name = "Telefone")]
        public string Phone { get; set; }
    }

}