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
        BookService BookService = new BookService();
        public LoanService()
        {
            _context = new LibraryDbContext();
        }

        // Create
        public string[] AddLoan(Loan loan)
        {
            string[] response = new string[2];
            bool result = false;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
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
                    BookService.UpdateBookCopyStatus(loan.CopyID, "Empréstimo");

                    transaction.Commit();
                    result = true;
                    response[0] = $"Empréstimo criado com sucesso!";
                    response[1] = result.ToString();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    result = false;
                    response[0] = $"Erro, não foi possível criar o empréstimo\n{ex.Message}";
                    response[1] = result.ToString();
                }
            }
            return response;
        }

        //Mark Loam as returned
        public void MarkLoanAsReturned(int loanId)
        {
            var loan = _context.Loans.FirstOrDefault(l => l.LoanID == loanId);
            if (loan != null)
            {
                loan.Status = "Devolvido";
                loan.ReturnedDate = DateTime.Now;
                _context.SaveChanges();

                BookService.UpdateBookCopyStatus(loan.CopyID, "Disponível");
                _context.LoanHistories.Add(new LoanHistory
                {
                    LoanID = loan.LoanID,
                    MemberID = loan.MemberID,
                    Event = "Book Returned",
                    EventDate = DateTime.Now,
                    Details = $"Book with ISBN {loan.ISBN} returned."
                });
                _context.SaveChanges();
            }
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
