using System;
using System.Collections.Generic;
using System.Text;

namespace WMS
{
    public class Category
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public List<Item> listOfItems = new List<Item>();
    }
   

}
