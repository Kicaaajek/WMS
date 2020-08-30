using System;
using System.Collections.Generic;
using System.Linq;
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
        public void AddQuantity(string nameItem, int number)
        {
            foreach (var item in Items)
            {
                if (item.Name == nameItem)
                {
                    item.Quantity += number;
                }
            }
        }
        public int RemoveQuantity(string nameItem, int number)
        {
            int quantity = 0;
            foreach (var item in Items)
            {
                if (item.Name == nameItem)
                {
                    quantity = item.Quantity;
                    if (item.Quantity >= number)
                    {
                        item.Quantity -= number;

                        if (item.Quantity == 0)
                        {
                            RemoveItem(item);
                        }
                    }
                }
            }
            return quantity;
        }
        public int GetQuantity(string nameItem)
        {
            int quantity = 0;
            foreach (var item in Items)
            {
                if (item.Name == nameItem)
                {
                    quantity = item.Quantity;
                }
            }
            return quantity;
        }
        public string[] GetAll()
        {
            string[] name= new string[Items.Count];
            int a = 0;
            foreach (var i in Items)
            {
                name[a] = i.Name;
                a++;
            }
            return name;
        }
        public List<Item> IsLow()
        {
            return Items.Where(i => i.Quantity < 5).ToList();
        }
    }
}
