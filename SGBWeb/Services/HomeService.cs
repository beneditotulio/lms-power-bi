using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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

        public List<LoanHistoryViewModel> GetRecentLoanActivities()
        {
            var recentActivities = _context.LoanHistories
                .Include(b => b.Loan)
                .Include(b => b.Member)
                .OrderByDescending(lh => lh.EventDate)
                .Take(5) // Adjust as needed to fetch the desired number of activities
                .ToList();

            // Convert LoanHistory entities to LoanHistoryViewModels
            var activityViewModels = recentActivities.Select(lh => new LoanHistoryViewModel
            {
                TimeAgo = CalculateTimeAgo(lh.EventDate), // You need to implement this method
                BadgeColor = GetBadgeColor(lh.Event), // You need to implement this method
                ActivityContent = FormatActivityContent(lh) // You need to implement this method
            }).ToList();

            return activityViewModels;
        }

        private string CalculateTimeAgo(DateTime eventDate)
        {
            TimeSpan timeSinceEvent = DateTime.Now - eventDate;
            if (timeSinceEvent.TotalMinutes < 60)
            {
                return $"{(int)timeSinceEvent.TotalMinutes} min";
            }
            else if (timeSinceEvent.TotalHours < 24)
            {
                return $"{(int)timeSinceEvent.TotalHours} hrs";
            }
            else if (timeSinceEvent.TotalDays < 7)
            {
                return $"{(int)timeSinceEvent.TotalDays} dias";
            }
            else
            {
                return $"{(int)(timeSinceEvent.TotalDays / 7)} semanas";
            }
        }

        private string GetBadgeColor(string events)
        {
            // Implement logic to determine badge color based on event type
            // Example:
            if (events == "Book Returned")
            {
                return "text-success";
            }
            else if (events == "Loan Created")
            {
                return "text-primary";
            }
            else
            {
                return "text-secondary";
            }
        }

        private string FormatActivityContent(LoanHistory loanHistory)
        {
            // Format the activity content based on event type and details
            // Example:
            if (loanHistory.Event == "Book Returned")
            {
                return $"Livro com ISBN {loanHistory.Loan.Book.ISBN} devolvido {loanHistory.Loan.Member.FullName} .";
            }
            else if (loanHistory.Event == "Loan Created")
            {
                return $"Emprestimo com ISBN {loanHistory.Loan.Book.ISBN} {loanHistory.Loan.Book.Title} criado.";
            }
            else
            {
                return loanHistory.Details; // Or any other format you need
            }
        }



    }

}