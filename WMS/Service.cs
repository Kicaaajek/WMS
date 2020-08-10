using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace WMS
{
    public class Service
    {
        public List<Item> listOfItems = new List<Item>();
        public void AddItem()
        {
            Console.WriteLine("What item do you want to add?");
            string nameItem = Console.ReadLine();
            bool beExist = listOfItems.Exists(Item => Item.Name == nameItem);
            if(beExist)
            {
                Console.WriteLine("How many items do you want to add?");
                int.TryParse(Console.ReadLine(), out int number);
                foreach (var item in listOfItems)
                {
                    if(item.Name==nameItem)
                    {
                        item.Quantity += number;
                    }
                    Console.WriteLine($"You add {number} {nameItem}`s.");
                }
            }
            else
            {
                Console.WriteLine("How many items do you want to add?");
                int.TryParse(Console.ReadLine(), out int number);
                Item item = new Item(listOfItems.Count, nameItem, number);
                listOfItems.Add(item);
                Console.WriteLine($"You add {number} {nameItem}`s.");
            }
        }
        public void RemoveItem()
        {
            Console.WriteLine("What item do you want to add?");
            string nameItem = Console.ReadLine();
            bool beExist = listOfItems.Exists(Item => Item.Name == nameItem);
            if (beExist)
            {
                Console.WriteLine("How many items do you want to remove?");
                int.TryParse(Console.ReadLine(), out int number);
                foreach (var item in listOfItems)
                {
                    if (item.Name == nameItem)
                    {
                        if (item.Quantity >= number)
                        {
                            item.Quantity -= number;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you want remove too many items. You don`t have it on stock");
                        }
                    }
                    Console.WriteLine($"You remove {number} {nameItem}`s.");
                }
            }
            else
            {
                Console.WriteLine($"Sorry, it`s impossible. You don`t have {nameItem} on stock");
            }
        }
        public void Availability()
        {
            Console.WriteLine("What quantity product do you want to check?");
            string nameItem = Console.ReadLine();
            bool beExist = listOfItems.Exists(Item => Item.Name == nameItem);
            if(beExist)
            {
                foreach(var item in listOfItems)
                {
                    if(item.Name==nameItem)
                    {
                        Console.WriteLine("The quantity of product is: " + item.Quantity);
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry, this product is out of stock");
            }
        }
        public void IsLowLevel()
        {
            Console.WriteLine("What item do you want to check that run out?");
            string nameItem = Console.ReadLine();
            bool beExist = listOfItems.Exists(Item => Item.Name == nameItem);
            if (beExist)
            {
                foreach (var item in listOfItems)
                {
                    item.IsLowAlert();
                }
            }
            else
            {
                Console.WriteLine("Sorry, this product is out of stock");
            }
        }
        //public List<Category> listOfCategories = new List<Category>();
      /*  public void AddItem()
        {
            Console.WriteLine("What is category of item which you want to add?");
            string oCategoryName = Console.ReadLine();
            //Item foundItem = listOfItem.Find(oElement => oElement.name == variable);
            bool beExist = listOfCategories.Exists(Category => Category.Name.Equals(oCategoryName));
            if (beExist == true)
            {
                Console.WriteLine("What item do you want to add?");
                string oItemName = Console.ReadLine();
                bool beExisted = Category.listOfItems.Exists(Item => Item.Name.Equals(oItemName));

                if (beExisted == true)
                {
                    Console.WriteLine("How many items do you want to add?");
                    int x;
                    int.TryParse(Console.ReadLine(), out int a);
                    Item findItem = listOfItems.Find(Item => Item.Name == oItemName);
                    findItem.Quantity += a;
                }
                else
                {
                    Console.WriteLine("How many items do you want to add?");
                    int x;
                    x = int.Parse(Console.ReadLine());
                    int id = listOfItems.Count;
                    listOfItems.Add(new Item(oCategoryName.Id,id++, oItemName, x, true));


                }
            }
            else
            {
                int countCategory = listOfCategories.Count;
                listOfCategories.Add(new Category(countCategory, oCategoryName));
                Console.WriteLine("What item do you want to add?");
                string oItemName = Console.ReadLine();
                //List<Item> oCategoryName = new List<Item>();
                Console.WriteLine("How many items do you want to add?");
                int.TryParse(Console.ReadLine(),out int x);
                //oCategoryName.Add(new Item(countCategory, 1, oItemName, x));
            }
        }*/
    }
}
