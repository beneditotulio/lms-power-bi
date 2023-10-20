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
    }

}