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
        private CategoryService _categoryService;
        public ItemManager()
        {
            _itemService = new ItemService();
            _categoryService = new CategoryService();
        }
        public void AddItem()
        {
            Console.WriteLine("What is category of item which you want to add?");
            string nameCat = Console.ReadLine();
            bool beExistCategory = _categoryService.Existed(nameCat);
            if (beExistCategory)
            {
                Console.WriteLine("What item do you want to add?");
                string nameItem = Console.ReadLine();
                bool beExist = _itemService.Existed(nameItem);
                Console.WriteLine("How many items do you want to add?");
                int.TryParse(Console.ReadLine(), out int number);
                if (beExist)
                {
                    foreach (var item in _itemService.Items)
                    {
                        if (item.Name == nameItem)
                        {
                            item.Quantity += number;
                        }
                        Console.WriteLine($"You add {number} {nameItem}`s.");
                    }
                }
                else
                {
                    int idCat = 0;
                    foreach (var c in _categoryService.Items)
                    {
                        if (c.CategoryName == nameCat)
                        {
                            idCat = c.Id;
                        }
                        break;
                    }
                    int itemId = _itemService.GetLastId();
                    Item item = new Item(idCat, nameCat, itemId++, nameItem, number);
                    _itemService.AddItem(item);
                    Console.WriteLine($"You add {number} {nameItem}`s.");
                }
            }
            else
            {
                int catId = _categoryService.GetLastId();
                Category category = new Category(catId++, nameCat);
                _categoryService.AddItem(category);
                Console.WriteLine("What item do you want to add?");
                string nameItem = Console.ReadLine();
                Console.WriteLine("How many items do you want to add?");
                int.TryParse(Console.ReadLine(), out int number);
                int itemId = _itemService.GetLastId();
                Item item = new Item(catId++, nameCat, itemId++, nameItem, number);
                _itemService.AddItem(item);
                Console.WriteLine($"You add {number} {nameItem}`s.");
            }
        }

        public void RemoveItem()
        {
            Console.WriteLine("What item do you want to remove?");
            string nameItem = Console.ReadLine();
            bool beExist = _itemService.Existed(nameItem);
            if (beExist)
            {
                Console.WriteLine("How many items do you want to remove?");
                int.TryParse(Console.ReadLine(), out int number);
                foreach (var item in _itemService.Items)
                {
                    if (item.Name == nameItem)
                    {
                        if (item.Quantity >= number)
                        {
                            item.Quantity -= number;
                            Console.WriteLine($"You remove {number} {nameItem}`s.");
                            if(item.Quantity==0)
                            {
                                _itemService.Items.Remove(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, you want remove too many items. You don`t have it on stock");
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine($"Sorry, it`s impossible. You don`t have {nameItem} on stock");
            }
        }
        public void Availability()
        {
            Console.WriteLine("What availability of product do you want to check?");
            string nameItem = Console.ReadLine();
            bool beExist = _itemService.Existed(nameItem);
            if (beExist)
            {
                foreach (var item in _itemService.Items)
                {
                    if (item.Name == nameItem)
                        Console.WriteLine("The quantity of product is: " + item.Quantity);
                }
            }
            else
            {
                Console.WriteLine("Sorry, this product is out of stock");
            }
        }
        public void IsLowLevel()
        {
            foreach (var item in _itemService.Items)
            {
                if (!item.OnStock)
                {
                    Console.WriteLine($"Sorry, {item.Name} is out of stock ");
                }
                else
                {
                    item.IsLow();
                }
            }

        }


    }
}
