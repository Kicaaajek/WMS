using System;
using System.Collections.Generic;
using System.Text;

namespace WMS
{
    public class Category 
    {
        public int CategoryId { get;}
        public  string CategoryName { get; set; }
        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
       
    }
   

}
