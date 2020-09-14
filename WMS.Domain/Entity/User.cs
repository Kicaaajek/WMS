using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WMS.Domain.Common;

namespace WMS.Domain
{
    public class User : BaseEntity
    {
        [XmlElement("UserName")]
        public string UserName { get; set; }
        public User(int userId, string userName)
        {
            Id = userId;
            UserName = userName;
        }
        public User()
        {

        }
    }
    
}
