using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WMS.Domain.Common;

namespace WMS.Domain
{
    public class Item :BaseEntity 
    { 
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Quantity")]
        public int Quantity { get; set; }
        [XmlElement("Category")]
        public Category Category { get; set; }
        //public bool OnStock { get; set; }
        public Item(int categoryId, string categoryName, int id, string name, int quantity) //: base(categoryId, categoryName)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Category.Id = categoryId;
            Category.CategoryName = categoryName;
        }
        public Item()
        {

        }
    }
}
