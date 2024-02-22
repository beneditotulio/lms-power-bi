using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SGBWeb.Services
{
    public class SettingService
    {
        private readonly LibraryDbContext _context;

        public SettingService()
        {
            _context = new LibraryDbContext();
        }

        // Create
        public void AddSetting(Setting setting)
        {
            _context.Settings.Add(setting);
            _context.SaveChanges();
        }

        // Read
        public Setting GetSetting(int id)
        {
            return _context.Settings.FirstOrDefault(s => s.Id == id);
        }
        //GetDefaultSetting
        public Setting GetDefaultSetting()
        {
            return _context.Settings.FirstOrDefault();
        }
        public IEnumerable<Setting> GetAllSettings()
        {
            return _context.Settings.ToList();
        }

        // Update
        public void UpdateSetting(Setting setting)
        {
            _context.Entry(setting).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Delete
        public void DeleteSetting(int id)
        {
            var setting = _context.Settings.Find(id);
            if (setting != null)
            {
                _context.Settings.Remove(setting);
                _context.SaveChanges();
            }
        }
    }

}