using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGBWeb.Models
{
    [Table("Loans")]
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("ID do Empréstimo")]
        public int LoanID { get; set; }

        [ForeignKey("Book")]
        [DisplayName("ISBN")]
        public string ISBN { get; set; }

        [ForeignKey("Copy")]
        [DisplayName("ID da Cópia")]
        public int CopyID { get; set; }

        [ForeignKey("Member")]
        [DisplayName("ID do Membro")]
        public string MemberID { get; set; }

        [ForeignKey("User")]
        [DisplayName("ID do Usuário")]
        public string UserId { get; set; }

        [DisplayName("Data do Empréstimo")]
        public DateTime LoanDate { get; set; }

        [DisplayName("Data de Vencimento")]
        public DateTime DueDate { get; set; }

        [DisplayName("Data de Devolução")]
        public DateTime? ReturnedDate { get; set; }
        [DisplayName("Estado")]
        public string Status { get; set; }

        // Navigation properties
        public virtual Book Book { get; set; }
        public virtual Copy Copy { get; set; }
        public virtual Member Member { get; set; }
        public virtual Member User { get; set; } // Assuming

    }
}