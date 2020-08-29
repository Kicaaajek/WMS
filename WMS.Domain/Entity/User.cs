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
    }
    
}
