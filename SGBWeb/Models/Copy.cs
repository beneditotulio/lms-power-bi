using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    [Table("Copies")]
    public class Copy
    {
        [Key]
        public int CopyID { get; set; }

        [Required]
        public string ISBN { get; set; }

        [ForeignKey("ISBN")]
        public Book Book { get; set; }

        [Required]
        [Display(Name = "Número da Cópia")]
        public int CopyNumber { get; set; }

        [Required]
        [Display(Name = "Condição")]
        public string Condition { get; set; }

    }

}