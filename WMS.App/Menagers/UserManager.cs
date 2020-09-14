using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using WMS.App.Concrete;

namespace WMS.App.Menagers
{
    public class UserManager
    {
        /* private UserService _userService;
         public UserManager(UserService userService)
         {
             _userService = userService;
         }*/
        private UserService _userService = new UserService();
        public UserManager()
        {

        }
        public void Login()
        {
            bool isCorrect=false;
            do
            {
                Console.WriteLine("Please write your ID number");
                int.TryParse(Console.ReadLine(), out int userId);
                Console.WriteLine("Please write your user name");
                string userName = Console.ReadLine();
                bool empty = _userService.Empty();
                if (!empty)
                {
                    Console.WriteLine("You are a new users");
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("1.Add new users");
                    Console.WriteLine("2.Exit");
                    int.TryParse(Console.ReadLine(), out int choice);
                    switch (choice)
                    {
                        case 1:
                            {
                                _userService.AddNewUser(userId, userName);
                                Console.WriteLine("Your data has been added");
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Goodbye!");
                                isCorrect = true;
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Sorry, You have chosen wrong number");
                                break;
                            }
                    }
                }
                else
                {
                    bool existedId = _userService.ExistedId(userId);
                    var existedName = _userService.ExistedName(userName);
                    if (existedId && existedName)
                    {
                        Console.WriteLine("Your data is correct");
                        isCorrect = true;
                    }
                    else if (existedId && !existedName)
                    {
                        Console.WriteLine("The entered name is incorrect");
                    }
                    else if (!existedId && existedName)
                    {
                        Console.WriteLine("The entered ID is incorrect");
                    }
                }
            } while (!isCorrect);
        }
    }
}
