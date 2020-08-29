using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.Domain.Common
{
    public class AuditableModel
    {
        public int CreatedById { get; set; }
        //public string CreatedByName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? ModifiedById { get; set; }
        //public string? ModifiedByName { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public AuditableModel()
        {
        }

        public void NewUser(int UserId, string UserName)
        {
            CreatedById = UserId;
            //CreatedByName = UserName;
            CreatedDateTime = DateTime.Today;
        }
        public void Modified(int UserId, string UserName)
        {
            ModifiedById = UserId;
           // ModifiedByName = UserName;
            ModifiedDateTime = DateTime.Today;
        }
    }
}
