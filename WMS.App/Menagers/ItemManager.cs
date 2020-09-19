using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using WMS.App.Concrete;
using WMS.Domain;

namespace WMS.App.Menagers
{
    public class ItemManager
    {
        /*private ItemService _itemService;
        private CategoryService _categoryService;
        public ItemManager(ItemService itemService, CategoryService categoryService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
        }*/
        private readonly ItemService _itemService = new ItemService();
        private readonly CategoryService _categoryService = new CategoryService();
        public ItemManager()
        {

        }
        public void AddItem()
        {
            Console.WriteLine("What is category of item which you want to add?");
            string nameCat = Console.ReadLine();
            bool beExistCategory;
            bool isEmpty = _categoryService.Empty();
            if (isEmpty)
                beExistCategory = false;
            else
                beExistCategory = _categoryService.Existed(nameCat);
            if (beExistCategory)
            {
                Console.WriteLine("What item do you want to add?");
                string nameItem = Console.ReadLine();
                bool beExist = _itemService.Existed(nameItem);
                Console.WriteLine("How many items do you want to add?");
                int.TryParse(Console.ReadLine(), out int number);
                if (beExist)
                {
                    _itemService.AddQuantity(nameItem, number);
                    Console.WriteLine($"You add {number} {nameItem}`s.");                    
                }
                else
                {
                    int idCat = _categoryService.GetCatId(nameCat);
                    int itemId = _itemService.GetLastId();
                    Item item = new Item(idCat, nameCat, itemId+1, nameItem, number);
                    _itemService.AddItem(item);
                    _itemService.UpdateNewItem(item);
                    Console.WriteLine($"You add {number} {nameItem}`s.");
                }
            }
            else
            {
                int catId = _categoryService.GetLastId();
                Category category = new Category(catId+1, nameCat);
                _categoryService.AddItem(category);
                _categoryService.UpdateNewCategory(category);
                Console.WriteLine("What item do you want to add?");
                string nameItem = Console.ReadLine();
                Console.WriteLine("How many items do you want to add?");
                int.TryParse(Console.ReadLine(), out int number);
                int itemId = _itemService.GetLastId();
                Item item = new Item(catId+1, nameCat, itemId+1, nameItem, number);
                _itemService.AddItem(item);
                _itemService.UpdateNewItem(item);
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
                int quantity=_itemService.RemoveQuantity(nameItem, number);
                if(quantity>=number)
                {
                    Console.WriteLine($"You removed {number} {nameItem}");
                    if(quantity==number)
                    {
                        Console.WriteLine($"The {nameItem} is out of stock now");
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, you want remove too many items. You don`t have it on stock");
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
                int quantity = _itemService.GetQuantity(nameItem);
                Console.WriteLine("The quantity of product is: " + quantity);
            }
            else
            {
                Console.WriteLine("Sorry, this product is out of stock");
            }
        }
        public void IsLowLevel()
        {
            if (_itemService.IsLow().Any())
            {
                foreach (var i in _itemService.IsLow())
                {
                    Console.WriteLine($"The {i.Name}");
                }
            }
            else
            {
                Console.WriteLine("Any item doesn`t have quantity lower than 5");
            }
            
        }
        public void ShowItems()
        {
            foreach(var i in _itemService.GetAll())
            {
                Console.WriteLine($"{i.Id}. {i.Name}");
            }
        }
        public void ShowCategories()
        {
            foreach (var i in _categoryService.GetAll())
            {
                Console.WriteLine($"{i.Id}. {i.CategoryName}");
            }
        }
    }
}
