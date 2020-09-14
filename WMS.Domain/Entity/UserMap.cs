using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.Domain.Entity
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Map(m => m.Id).Name("UserId");
            Map(m => m.UserName).Name("UserName");
        }
    }
}
