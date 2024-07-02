using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBWeb.Services
{
    public class HomeService
    {
        private readonly LibraryDbContext _context;

        public HomeService()
        {
            _context = new LibraryDbContext();
        }

        public int GetTotalLoans()
        {
            return _context.Loans.Count();
        }

        public double GetLoanIncreasePercentage()
        {
            var loansLastYear = _context.Loans
                .Where(l => l.LoanDate.Year == DateTime.Now.Year - 1).Count();
            var loansThisYear = _context.Loans
                .Where(l => l.LoanDate.Year == DateTime.Now.Year).Count();

            if (loansLastYear == 0) return 100;
            return ((double)(loansThisYear - loansLastYear) / loansLastYear) * 100;
        }

        public double GetTotalFines()
        {
            var dailyFine = (double)_context.Settings.First().DailyFine;
            return _context.Loans
                .Where(l => l.ReturnedDate > l.DueDate)
                .AsEnumerable()  // Traz os dados para a memória
                .Sum(l => (l.ReturnedDate.Value - l.DueDate).Days * dailyFine);
        }

        public double GetFineIncreasePercentage()
        {
            var dailyFine = (double)_context.Settings.First().DailyFine;
            var finesLastYear = _context.Loans
                .Where(l => l.ReturnedDate > l.DueDate && l.LoanDate.Year == DateTime.Now.Year - 1)
                .AsEnumerable()  // Traz os dados para a memória
                .Sum(l => (l.ReturnedDate.Value - l.DueDate).Days * dailyFine);

            var finesThisYear = _context.Loans
                .Where(l => l.ReturnedDate > l.DueDate && l.LoanDate.Year == DateTime.Now.Year)
                .AsEnumerable()  // Traz os dados para a memória
                .Sum(l => (l.ReturnedDate.Value - l.DueDate).Days * dailyFine);

            if (finesLastYear == 0) return 100;
            return ((finesThisYear - finesLastYear) / finesLastYear) * 100;
        }


        public int GetTotalMembers()
        {
            return _context.Members.Count();
        }

        public double GetMemberIncreasePercentage()
        {
            var membersLastYear = _context.Members
                .Where(m => m.DateCreate.Year == DateTime.Now.Year - 1).Count();
            var membersThisYear = _context.Members
                .Where(m => m.DateCreate.Year == DateTime.Now.Year).Count();

            if (membersLastYear == 0) return 100;
            return ((double)(membersThisYear - membersLastYear) / membersLastYear) * 100;
        }

        public List<RecentFineViewModel> GetRecentFines()
        {
            // Carregar as configurações de multa
            var dailyFine = _context.Settings.First().DailyFine ?? 0m; // Lidar com valor nulo

            // Executar a consulta de empréstimos e multas
            var loansWithFines = _context.Loans
                .Where(l => l.ReturnedDate > l.DueDate)
                .OrderByDescending(l => l.ReturnedDate)
                .ToList(); // Carregar todos os empréstimos no contexto atual

            // Converter para ViewModel
            var recentFines = loansWithFines
                .Select(l => new RecentFineViewModel
                {
                    LoanId = l.LoanID,
                    MemberName = l.Member.FirstName + " " + l.Member.LastName,
                    BookTitle = l.Book.Title,
                    FineAmount = ((decimal)(l.ReturnedDate.Value - l.DueDate).Days) * dailyFine,
                    Status = l.Status
                })
                .Take(5) // Ajuste conforme necessário
                .ToList();

            return recentFines;
        }

    }

}