using SGBWeb.Data;
using SGBWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SGBWeb.Helpers
{
    public class MemberHelper
    {
        //public static string GenNewMemberId(string memberType)
        //{
        //    return memberType;
        //}

        public static string GenNewMemberId()
        {
            using (var context = new LibraryDbContext())
            {
                string serie = $"MBR/";
                var maxNumDoc = context.Members
                                       .Where(so => so.MemberID.StartsWith(serie))
                                       .OrderByDescending(so => so.MemberID)
                                       .Select(so => so.MemberID)
                                       .FirstOrDefault();

                int maxSequenceNumber = 0;
                if (!string.IsNullOrEmpty(maxNumDoc))
                {
                    var parts = maxNumDoc.Split('/');
                    if (parts.Length > 0 && int.TryParse(parts[0], out int sequenceNumber))
                    {
                        maxSequenceNumber = sequenceNumber;
                    }
                }

                int newSequenceNumber = maxSequenceNumber + 1;
                return $"{serie}{newSequenceNumber.ToString("000000")}";
            }
        }
    }
}   