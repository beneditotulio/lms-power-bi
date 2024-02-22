using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGBWeb.Models
{
    [Table("Settings")]
    public class Setting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Multa Inicial")]
        //[Column(TypeName = "decimal(18, 2)")]
        public decimal? InitialFine { get; set; }

        [DisplayName("Multa Diária")]
        //[Column(TypeName = "decimal(18, 2)")]
        public decimal? DailyFine { get; set; }

        [DisplayName("Dias para Devolução")]
        public int? DaysForReturn { get; set; }

        [DisplayName("Empréstimo por Pessoa")]
        public int? LoanByPerson { get; set; }
    }
}
