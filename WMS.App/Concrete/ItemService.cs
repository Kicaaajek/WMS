using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using WMS.App.Concrete;
using WMS.Domain;

namespace WMS.App
{
    public class ItemService : BaseService<Item>
    {
        public bool Existed(string nameItem)
        {
            bool beExist = Items.Exists(p => p.Name == nameItem);
            return beExist;
        }
        public void ShowItems()
        {
            foreach (var item in GetAllItems())
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }
    }
}
