using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.Domain
{
    public class Item : Category 
    { 
        public string Name { get; set; }
        public int Quantity { get; set; }
        //public bool OnStock { get; set; }
        public Item(int categoryId, string categoryName, int id, string name, int quantity) : base(categoryId, categoryName)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
    }
}
