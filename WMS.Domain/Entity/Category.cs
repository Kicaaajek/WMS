using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using WMS.Domain.Common;

namespace WMS
{
    public class Category : BaseEntity
    {
        [XmlElement("CategoryName")]
        public  string CategoryName { get; set; }
        public Category(int categoryId, string categoryName)
        {
            Id = categoryId;
            CategoryName = categoryName;
        }
        public Category()
        {

        }
       
    }
   

}
