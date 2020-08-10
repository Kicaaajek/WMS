using System;
using System.Collections.Generic;
using System.Text;

namespace WMS
{
    public class Item
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool OnStock { get; set;}
        public Item(int id, string name, int quantity)
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
        public void IsLowAlert()
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
