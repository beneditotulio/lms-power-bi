using System;
using System.Collections.Generic;
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
        [StringLength(50)]
        public string ParentId { get; set; }

        [Required]
        [StringLength(50)]
        public string ClassifierType { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(10)]
        public string ShortName { get; set; }

        [Required]
        public int IsDefault { get; set; }

        [Required]
        [StringLength(50)]
        public string ExtCode { get; set; }
    }

}