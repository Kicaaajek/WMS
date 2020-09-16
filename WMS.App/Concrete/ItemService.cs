using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using WMS.App.Concrete;
using WMS.Domain;
using WMS.Domain.Common;
using WMS.Domain.Entity;

namespace WMS.App
{
    public class ItemService : BaseService<Item>
    {
        private readonly string path = @"C:\Users\zajce\Desktop\pracainżynierska\KursDotNEtaMagazyn\Warehouse\WMS\WMS\bin\Debug\netcoreapp3.1\Items.xml";
        public ItemService()
        {
            Items = Load("Items",path);
        }
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
                    UpdateItem(item, item.Quantity);
                }
            }
        }
        public void UpdateNewItem(Item item)
        {
            AddNewItem(item, "Items", path);
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
                        else
                        {
                            UpdateItem(item, quantity);
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
        public List<Item> GetAll()
        {
            var list = new List<Item>();
            foreach (var i in Items)
            {
                list.Add(i);
            }
            return list;
        }
        public List<Item> IsLow()
        {
            return Items.Where(i => i.Quantity < 5).ToList();
        }
        public void UpdateItem(Item item, int quantity)
        {
            XDocument xml = XDocument.Load("Items.xml");
            var i = xml.Root.Elements("Item").Where(i => i.Attribute("Id").Value == item.Id.ToString());
            if(i.Any())
            {
                i.First().Element("Quantity").Value = quantity.ToString();
            }
            xml.Save(@"Items.xml");
        }
        /*
        public void NewUser(int UserId, string UserName)
        {
            AuditableModel.CreatedById = UserId;
            AuditableModel.CreatedByName = UserName;
            AuditableModel.CreatedDateTime = DateTime.Today;
        }
        public void Modified(int UserId, string UserName)
        {
            ModifiedById = UserId;
            ModifiedByName = UserName;
            ModifiedDateTime = DateTime.Today;
        }*/

    }    
}
