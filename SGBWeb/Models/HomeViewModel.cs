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
    }
}