using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WMS.Domain.Common;

namespace WMS.Domain
{
    public class Item : Category 
    {  
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
        public Item()
        {

        }
        public Item(int categoryId, string categoryName, int id, string name, int quantity) : base(categoryId, categoryName)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
