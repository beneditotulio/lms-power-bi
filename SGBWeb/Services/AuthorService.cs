using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGBWeb.Services
{
    public class AuthorService
    {
        private readonly LibraryDbContext _context;

        public AuthorService()
        {
            _context = new LibraryDbContext();
        }

        public List<Author> GetAllAuthors()
        {
            return _context.Authors
                .Include(c=>c.Country)
                .ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.Find(id);
        }

        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteAuthor(int id)
        {
            var author = _context.Authors.Find(id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
        }

        public bool ExistsAuthorName(string authorName)
        {
            bool result = false;
            var author = _context.Authors.FirstOrDefault(p => p.AuthorName == authorName);
            if (author != null)
            {
                result = true;
            }
            return result;
        }
        public static string ImportAuthor(Syncfusion.XlsIO.IWorkbook workbook, Syncfusion.XlsIO.IWorksheet worksheet)
        {
            string ErrorLogs = string.Empty;
            string response = string.Empty;
            //bool result = false;

            using (var context = new LibraryDbContext())
            using (var t = context.Database.BeginTransaction())
            {
                AuthorService authorService = new AuthorService();

                int total = 0;
                List<Author> authorsList = new List<Author>();
                Author author = new Author();
                try
                {
                    const int initPosition = 2; // primeira linha com informacao do codigo
                    //total = workbook.ActiveSheet.UsedRange.Columns.Length;
                    total = workbook.ActiveSheet.UsedRange.Rows.Length;
                    for (int i = initPosition; i <= total; i++)
                    {
                        string authorName = workbook.ActiveSheet.Range["B" + i].Value;
                        if (!string.IsNullOrEmpty(authorName))
                        {
                            author = new Author
                            {

                                AuthorName = authorName,
                                DateOfBirth = new DateTime(1900, 01, 01),
                                CountryOfOrigin = "CTR0000",
                                Biography = "N/A",
                                Website = "",
                                Email = "",
                                Phone = "0000"
                            };

                            authorsList.Add(author);
                        }
                    }

                    foreach (var item in authorsList)
                    {
                        //Verifica a existencia da editora, caso nao exista, cria
                        if (!authorService.ExistsAuthorName(item.AuthorName))
                        {
                            authorService.AddAuthor(item);
                        }
                    }

                    response = $"{total} autores importados com sucesso!";
                }
                catch (Exception ex)
                {
                    t.Rollback();
                    response = "Erro não foi possível importar autores! " + ex;
                }
            }
            return response;
        }

    }

}