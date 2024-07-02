using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBWeb.Models
{
    public class HomeViewModel
    {
        public int TotalLoans { get; set; }
        public double LoanIncreasePercentage { get; set; }
        public double TotalFines { get; set; }
        public double FineIncreasePercentage { get; set; }
        public int TotalMembers { get; set; }
        public double MemberIncreasePercentage { get; set; }
        public List<RecentFineViewModel> RecentFines { get; set; } // Adicionar isso
    }

    public class RecentFineViewModel
    {
        public int LoanId { get; set; }
        public string MemberName { get; set; }
        public string BookTitle { get; set; }
        public decimal FineAmount { get; set; }
        public string Status { get; set; }
    }
}