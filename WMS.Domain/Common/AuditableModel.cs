using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace WMS.Domain.Common
{
    public class AuditableModel
    {/*
        [XmlIgnore]
        public int CreatedById { get; set; }
        public string CreatedByName { get; set; }
        [XmlIgnore]
        public DateTime CreatedDateTime { get; set; }
        [XmlIgnore]
        public int? ModifiedById { get; set; }
        public string? ModifiedByName { get; set; }
        [XmlIgnore]
        public DateTime? ModifiedDateTime { get; set; }*/
        public AuditableModel()
        {
        }
    }
}
