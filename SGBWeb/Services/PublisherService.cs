using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBWeb.Services
{
    public class PublisherService
    {
        private readonly LibraryDbContext _dbContext; // Replace YourDbContext with your actual Entity Framework DbContext

        public PublisherService()
        {
            _dbContext = new LibraryDbContext();
        }

        // Create a new publisher
        public Publisher CreatePublisher(Publisher publisher)
        {
            _dbContext.Publishers.Add(publisher);
            _dbContext.SaveChanges();
            return publisher;
        }

        // Read (Retrieve) a publisher by ID
        public Publisher GetPublisherById(int publisherId)
        {
            return _dbContext.Publishers.Find(publisherId);
        }

        // Read (Retrieve) a publisher by Name
        public Publisher GetPublisherByName(string publisherName)
        {
            return _dbContext.Publishers.Find(publisherName);
        }
        //Check if the publisherName exists
        public bool ExistsPublisherName(string publisherName)
        {
            bool result = false;
            var publisher = _dbContext.Publishers.FirstOrDefault(p=>p.PublisherName == publisherName);
            if (publisher != null)
            {
                result = true;
            }
            return result;
        }
        // Read (Retrieve) all publishers
        public List<Publisher> GetAllPublishers()
        {
            return _dbContext.Publishers.ToList();
        }

        // Update an existing publisher
        public Publisher UpdatePublisher(Publisher updatedPublisher)
        {
            var existingPublisher = _dbContext.Publishers.Find(updatedPublisher.PublisherID);
            if (existingPublisher != null)
            {
                existingPublisher.PublisherName = updatedPublisher.PublisherName;
                existingPublisher.Address = updatedPublisher.Address;
                existingPublisher.Phone = updatedPublisher.Phone;
                _dbContext.SaveChanges();
            }
            return existingPublisher;
        }

        // Delete a publisher by ID
        public bool DeletePublisher(int publisherId)
        {
            var publisherToDelete = _dbContext.Publishers.Find(publisherId);
            if (publisherToDelete != null)
            {
                _dbContext.Publishers.Remove(publisherToDelete);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public static string ImportPublisher(Syncfusion.XlsIO.IWorkbook workbook, Syncfusion.XlsIO.IWorksheet worksheet)
        {
            string ErrorLogs = string.Empty;
            string response = string.Empty;
            bool result = false;

            using (var context = new LibraryDbContext())
            using (var t = context.Database.BeginTransaction())
            {
                PublisherService publisherService = new PublisherService();

                int total = 0, totalCounted = 0, rows = 0;
                List<string> code = new List<string>();
                List<Publisher> publisherList = new List<Publisher>();
                Publisher publisher = new Publisher();
                try
                {
                    const int initPosition = 1; // primeira linha com informacao do codigo
                    //total = workbook.ActiveSheet.UsedRange.Columns.Length;
                    total = workbook.ActiveSheet.UsedRange.Rows.Length;
                    for (int i = initPosition; i <= total; i++)
                    {
                        string publisherName = workbook.ActiveSheet.Range["B" + i].Value;
                        if (!string.IsNullOrEmpty(publisherName))
                        {
                            publisher = new Publisher
                            {

                                PublisherName = publisherName,
                                Address = "N/A",
                                Phone = "0000"
                            };

                            publisherList.Add(publisher);
                        }
                    }

                    foreach (var item in publisherList)
                    {
                        //Verifica a existencia da editora, caso nao exista, cria
                        if (!publisherService.ExistsPublisherName(item.PublisherName))
                        {
                            publisherService.CreatePublisher(item);
                        }
                    }

                    response = $"{total} editoras importadas com sucesso!";
                }
                catch (Exception ex)
                {
                    t.Rollback();
                    response = "Erro não foi possível importar editoras! ";
                }
            }
            return response;
        }
    }

}