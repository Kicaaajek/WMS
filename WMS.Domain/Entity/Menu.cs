using System;
using System.Collections.Generic;
using System.Text;
using WMS.Domain.Common;

namespace WMS.Domain.Entity
{
    public class Menu: BaseEntity
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public Menu(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
