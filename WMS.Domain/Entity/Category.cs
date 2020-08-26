using System;
using System.Collections.Generic;
using System.Text;
using WMS.Domain.Common;

namespace WMS
{
    public class Category : BaseEntity
    {
        //public int CategoryId { get;}
        public  string CategoryName { get; set; }
        public Category(int categoryId, string categoryName)
        {
            Id = categoryId;
            CategoryName = categoryName;
        }
       
    }
   

}
