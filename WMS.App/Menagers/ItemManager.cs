using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using WMS.App.Concrete;
using WMS.Domain;

namespace WMS.App.Menagers
{
    public class ItemManager 
    {
        private ItemService _itemService;
        public ItemManager()
        {
            _itemService= new ItemService();
        }
        public List<Category> listOfCategories = new List<Category>();
        public List<Item> listOfItems = new List<Item>();

        public void AddItem()
        {
            Console.WriteLine("What is category of item which you want to add?");
            string nameCat = Console.ReadLine();
            bool beExistCategory = listOfCategories.Exists(Category => Category.CategoryName == nameCat);
            if (beExistCategory)
            {
                Console.WriteLine("What item do you want to add?");
                string nameItem = Console.ReadLine();
                bool beExist = listOfItems.Exists(Item => Item.Name == nameItem);
                Console.WriteLine("How many items do you want to add?");
                int.TryParse(Console.ReadLine(), out int number);
                if (beExist)
                {
                    var newItem = _itemService.GetItemByName(nameItem);
                    newItem.Quantity += number;
                    Console.WriteLine($"You add {number} {nameItem}`s.");
                   /* foreach (var item in listOfItems)
                    {
                        if (item.Name == nameItem)
                        {
                            item.Quantity += number;
                        }
                        Console.WriteLine($"You add {number} {nameItem}`s.");
                    }*/
                }
                else
                {
                    // int idCat = _itemService.GetItemByName(nameCat).CategoryId;
                    int idCat = 0;
                    foreach (var c in listOfCategories)
                    {
                        if (c.CategoryName == nameCat)
                        {
                            idCat = c.CategoryId;
                        }
                        break;
                    }
                    Item item = new Item(idCat, nameCat, listOfItems.Count, nameItem, number);
                    _itemService.AddItem(item);
                    //listOfItems.Add(item);
                    Console.WriteLine($"You add {number} {nameItem}`s.");
                }
            }
            else
            {
                Category category = new Category(listOfCategories.Count, nameCat);
                listOfCategories.Add(category);
                Console.WriteLine("What item do you want to add?");
                string nameItem = Console.ReadLine();
                Console.WriteLine("How many items do you want to add?");
                int.TryParse(Console.ReadLine(), out int number);
                Item item = new Item(listOfCategories.Count, nameCat, listOfItems.Count, nameItem, number);
                _itemService.AddItem(item);
                Console.WriteLine($"You add {number} {nameItem}`s.");
            }
        }

        public void RemoveItem()
        {
            Console.WriteLine("What item do you want to remove?");
            string nameItem = Console.ReadLine();
            bool beExist = listOfItems.Exists(Item => Item.Name == nameItem);
            if (beExist)
            {
                Console.WriteLine("How many items do you want to remove?");
                int.TryParse(Console.ReadLine(), out int number);
                var item = _itemService.GetItemByName(nameItem);
                        if (item.Quantity >= number)
                        {
                            item.Quantity -= number;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you want remove too many items. You don`t have it on stock");
                        }
                    Console.WriteLine($"You remove {number} {nameItem}`s.");
            }
            else
            {
                Console.WriteLine($"Sorry, it`s impossible. You don`t have {nameItem} on stock");
            }
        }
        public void Availability()
        {
            Console.WriteLine("What quantity of product do you want to check?");
            string nameItem = Console.ReadLine();
            bool beExist = listOfItems.Exists(Item => Item.Name == nameItem);
            if (beExist)
            {
                var item = _itemService.GetItemByName(nameItem);
                Console.WriteLine("The quantity of product is: " + item.Quantity);
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
                var item = _itemService.GetItemByName(nameItem);
                    if (!item.OnStock)
                    {
                        Console.WriteLine($"Sorry, {item.Name} is out of stock ");
                    }
                    else
                    {
                        item.IsLow();
                    }
            }
            else
            {
                Console.WriteLine("Sorry, this product is out of stock");
            }
        }
        public void ShowCategories()
        {
            foreach (var cat in listOfCategories)
            {
                Console.WriteLine(cat.CategoryId + ". " + cat.CategoryName);
            }
        }

    }
}
