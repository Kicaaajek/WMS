using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq.Expressions;
using WMS.App;
using WMS.App.Concrete;
using WMS.App.Menagers;
using WMS.Domain;

namespace WMS
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            ItemService itemService = new ItemService();
            CategoryService categoryService = new CategoryService();
            MenuService menuService = new MenuService();
            ItemManager itemManager = new ItemManager();
            User user = new User();
            Console.WriteLine("Welcome to warehouse app!");
            user.Login();
            do
            {
                Console.WriteLine("Please let me know what do you want to do?");
                var menu = menuService.GetMenu();
                for(int i=0;i<menu.Count;i++)
                {
                    Console.WriteLine($"{menu[i].Id}. {menu[i].Name}");
                }
                Console.WriteLine("Please press correct number.");
                int.TryParse(Console.ReadLine(), out choice);
                Console.WriteLine($"You have chosen option number: {choice}.");
                switch (choice)
                {
                    case 1:
                        {
                            itemManager.AddItem();
                            break;
                        }
                    case 2:
                        {
                            itemManager.RemoveItem();
                            break;
                        }
                    case 3:
                        {
                            itemManager.Availability();
                            break;
                        }
                    case 4:
                        {
                            itemManager.IsLowLevel();
                            break;
                        }
                    case 5:
                        {
                            itemService.GetAllItems();
                            break;
                        }
                    case 6:
                        {
                            categoryService.GetAllItems();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine("Good bye!");
                            break;
                        }
                        
                    default:
                        {
                            Console.WriteLine("Sorry, You have chosen wrong number");
                            break;
                        }
                }
            } while (choice != 7);
        }

    }
}
