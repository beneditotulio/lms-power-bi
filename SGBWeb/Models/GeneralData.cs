using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    [Table("GeneralData")]
    public class GeneralData
    {
        [Key]
        [Required]
        [StringLength(50)]
        public string ID { get; set; }

        [Required]
        [StringLength(50), DisplayName("Parente")]
        public string ParentId { get; set; }

        [Required]
        [StringLength(50), DisplayName("Classificador")]
        public string ClassifierType { get; set; }

        [Required]
        [StringLength(255), DisplayName("Descrição")]
        public string Description { get; set; }

        [Required]
        [StringLength(10), DisplayName("Abreviatura")]
        public string ShortName { get; set; }

        [Required, DisplayName("Pre-Definido?")]
        public int IsDefault { get; set; }

        [Required]
        [StringLength(50)]
        public string ExtCode { get; set; }

        // Navigation property for relationships
        //public ICollection<Book> Books { get; set; }
    }

}