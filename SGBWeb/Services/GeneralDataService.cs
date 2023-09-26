using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBWeb.Services
{
    public class GeneralDataService
    {
        private readonly LibraryDbContext _context; 

        public GeneralDataService()
        {
            _context = new LibraryDbContext();
        }

        // Create a new GeneralData record
        public void CreateGeneralData(GeneralData generalData)
        {
            _context.GeneralDatas.Add(generalData);
            _context.SaveChanges();
        }

        // Retrieve a GeneralData record by ID
        public GeneralData GetGeneralDataById(string id)
        {
            return _context.GeneralDatas.FirstOrDefault(g => g.ID == id);
        }
        // Retrieve a GeneralData record by ID
        public List<GeneralData> GetAllGeneralDataByType(string classifierType)
        {
            return _context.GeneralDatas
                .Where(g => g.ClassifierType == classifierType)
                .ToList();
        }

        // Retrieve all GeneralData records
        public List<GeneralData> GetAllGeneralData()
        {
            return _context.GeneralDatas.ToList();
        }

        // Update an existing GeneralData record
        public void UpdateGeneralData(GeneralData generalData)
        {
            var toUpdate = _context.GeneralDatas.FirstOrDefault(g => g.ID == generalData.ID);
            if (generalData != null)
            {
                toUpdate.Description = generalData.Description;
                toUpdate.ShortName = generalData.ShortName;
                _context.SaveChanges();
            }
        }

        // Delete a GeneralData record by ID
        public void DeleteGeneralData(string id)
        {
            var generalData = _context.GeneralDatas.FirstOrDefault(g => g.ID == id);
            if (generalData != null)
            {
                _context.GeneralDatas.Remove(generalData);
                _context.SaveChanges();
            }
        }
    }

}