using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    [Table("LoanHistory")]
    public class LoanHistory
    {
        [Key]
        public int LoanHistoryID { get; set; }
        public int LoanID { get; set; }
        public string MemberID { get; set; }
        public string Event { get; set; }
        public DateTime EventDate { get; set; }
        public string Details { get; set; }

        // Navigation properties
        public Loan Loan { get; set; }
        public Member Member { get; set; }
    }

}