using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.Domain.Common
{
    public class AuditableModel
    {
        public int CreatedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime ModifiedDateTime { get; set; }

        /*
        public AuditableModel()
        {
        }

        public void NewUser()
        {
            CreatedById = UserId;
            //CreatedByName = UserName;
            CreatedDateTime = DateTime.Today;

        }
        public void Modified()
        {
            ModifiedById = UserId;
            //ModifiedByName = UserName;
            ModifiedDateTime = DateTime.Today;
        }*/
    }
}
