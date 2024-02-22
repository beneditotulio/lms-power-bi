using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SGBWeb.Services
{
    public class LoanService
    {
        private readonly LibraryDbContext _context;

        public LoanService()
        {
            _context = new LibraryDbContext();
        }

        // Create
        public void AddLoan(Loan loan)
        {
            _context.Loans.Add(loan);
            _context.SaveChanges();

            // Log the loan creation event
            _context.LoanHistories.Add(new LoanHistory
            {
                LoanID = loan.LoanID,
                MemberID = loan.MemberID,
                Event = "Loan Created",
                EventDate = DateTime.Now,
                Details = $"Loan for ISBN {loan.ISBN} created."
            });
            _context.SaveChanges();
        }

        // Read (single)
        public Loan GetLoanById(int loanId)
        {
            return _context.Loans.FirstOrDefault(l => l.LoanID == loanId);
        }

        // Read (all)
        public List<Loan> GetAllLoans()
        {
            return _context.Loans.Include(b=>b.Book).Include(c=>c.Copy).ToList();
        }

        // Update
        public void UpdateLoan(Loan loan)
        {
            _context.Entry(loan).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Delete
        public void DeleteLoan(int loanId)
        {
            var loan = _context.Loans.Find(loanId);
            if (loan != null)
            {
                _context.Loans.Remove(loan);
                _context.SaveChanges();
            }
        }
    }
}
