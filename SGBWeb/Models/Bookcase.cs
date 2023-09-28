using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    [Table("Bookcases")]
    public class Bookcase
    {
        [Key]
        public int BookcaseID { get; set; }

        [Required]
        [StringLength(255), DisplayName("Nome")]
        public string BookcaseName { get; set; }

        [StringLength(100), DisplayName("Localização")]
        public string Location { get; set; }
        [DisplayName("Capacidade")]

        public int? Capacity { get; set; }

        [StringLength(255), DisplayName("Descrição")]
        public string Description { get; set; }
    }

}