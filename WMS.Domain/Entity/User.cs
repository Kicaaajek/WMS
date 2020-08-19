using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public User(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
        public User()
        {

        }
        public void Login()
        {
            Console.WriteLine("Please write your ID number");
            int.TryParse(Console.ReadLine(), out int userId);
            Console.WriteLine("Please write your user name");
            string userName = Console.ReadLine();
            //User user = new User(userId,userName);
        }
    }
    
}
