using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.Domain.Entity
{
    public class ItemMap : ClassMap<Item>
    {
        public ItemMap()
        {
            //AutoMap();
            Map(m => m.Category.Id).Name("CategoryId");
            Map(m => m.Category.CategoryName).Name("CategoryName");
            Map(m => m.Id).Name("ItemId");
            Map(m => m.Name).Name("ItemName");
            Map(m => m.Quantity).Name("Quantity");
            
        }
    }
}
