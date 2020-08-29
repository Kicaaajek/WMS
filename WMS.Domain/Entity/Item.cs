using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.Domain
{
    public class Item : Category 
    { 
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool OnStock { get; set; }
        public Item(int categoryId, string categoryName, int id, string name, int quantity) : base(categoryId, categoryName)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }
       
        public void IsOnStock()
        {
            if(Quantity>0)
            {
                OnStock = true;
            }
            else
            {
                OnStock = false;
            }

        }
        public void IsLow()
        {
            if(Quantity<5)
            {
                Console.WriteLine($"Warning. The quantity of {Name} is less than 5");
            }
            else
            {
                Console.WriteLine($"Calm down! The quantity of {Name} is more than 5");
            }
        }
       



    }
}
