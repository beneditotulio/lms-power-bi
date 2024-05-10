using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace SGBWeb.Services
{
    public class MemberService
    {
        private readonly LibraryDbContext _context;

        public MemberService()
        {
            _context = new LibraryDbContext();
        }

        public string GetMemberIdByUserId(string userId)
        {
            return _context.Members.FirstOrDefault(x=>x.UserId == userId).MemberID;
        }

        public string GetMemberRoleByUserId(string userId)
        {
            return _context.Members.FirstOrDefault(x => x.UserId == userId).MemberType;
        }
        public string GetMemberRoleByUserName(string userName)
        {
            return _context.Members.FirstOrDefault(x => x.Email == userName).MemberType;
        }
        public Member GetMemberIByUserName(string userName)
        {
            return _context.Members.FirstOrDefault(x => x.Email == userName);
        }
        #region Generate New Id
        public string GetNewEntityId(string entityType)
        {
            string serie = string.Empty, newId = string.Empty;

            switch (entityType)
            {
                case "SYSTEM_USER":
                    serie = "US";
                    break;
                case "STUDENT":
                    serie = "STUD";
                    break;
            }
            newId = GetNewEntityId(serie, entityType);
            return newId;
        }
        private string GetNewEntityId(string serie, string entityType)
        {
            string entityId = _context.Members.Where(x => x.MemberID.Contains(serie)).Max(x => x.MemberID);
            var maxEntity = _context.Members.Where(e => e.MemberID == entityId).ToList();

            if (maxEntity == null || maxEntity.Count == 0)
            {
                Member entity = new Member();
                entity.MemberType = entityType;
                entity.MemberID = serie + "0001";
                maxEntity.Add(entity);
            }
            else
            {
                int lengthSerie = serie.Length;
                string tempStr = "1" + maxEntity[0].MemberID.ToString().Remove(0, lengthSerie).ToString();
                decimal tempDec = (Convert.ToDecimal(tempStr) + 1);
                string tempStr1 = tempDec.ToString();
                maxEntity[0].MemberID = serie + tempStr1.Remove(0, 1);
            }
            return maxEntity[0].MemberID;
        }
        #endregion
    }
}