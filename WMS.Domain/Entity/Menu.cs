using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WMS.Domain.Common;

namespace WMS.Domain.Entity
{
    public class Menu: BaseEntity
    {
        [XmlIgnore]
        public string Name { get; set; }
        public Menu(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
