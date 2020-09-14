using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.Domain.Entity
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Map(m => m.Id).Name("CategoryId");
            Map(m => m.CategoryName).Name("CategoryName");
        }
    }
}
