using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WMS.Domain.Common
{
    public class BaseEntity :AuditableModel
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }
        public BaseEntity()
        {

        }
    }
}
