using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq.Expressions;

namespace WMS
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            Service service = new Service();
            do
            {
                Console.WriteLine("Welcome to warehouse app!");
                Console.WriteLine("Please let me know what do you want to do?");
                Console.WriteLine("1. Add item");
                Console.WriteLine("2. Remove item");
                Console.WriteLine("3. Check availability of item");
                Console.WriteLine("4. Check which items are run out");
                Console.WriteLine("5. Close app");
                Console.WriteLine("Please press 1, 2, 3, 4 or 5.");
                choice = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"You have chosen option number: {choice}.");
                switch (choice)
                {
                    case 1:
                        {
                            service.AddItem();
                            break;
                        }
                    case 2:
                        {
                            service.RemoveItem();
                            break;
                        }
                    case 3:
                        {
                            service.Availability();
                            break;
                        }
                    case 4:
                        {
                            service.IsLowLevel();
                            break;
                        }
                    case 5:
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
            } while (choice == 5);
        }

    }
}
