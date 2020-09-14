using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using WMS.App.Concrete;
using WMS.Domain;
using WMS.Domain.Common;
using WMS.Domain.Entity;

namespace WMS.App
{
    public class ItemService : BaseService<Item>
    {
        private readonly string path = @"C:\Users\zajce\Desktop\pracainżynierska\KursDotNEtaMagazyn\Warehouse\WMS\Items.csv";
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
      
        /*
        public List<Item> Load()
        {
            var items = new List<Item>();
            XmlRootAttribute root = new XmlRootAttribute();
            root.ElementName = "Items";
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Item>), root);
            //if(!File.Exists())
            string output = File.ReadAllText(@"Items.xml");
            StringReader stringReader = new StringReader(output);
            items = (List<Item>)xmlSerializer.Deserialize(stringReader);
            return items;
            /*string fileName = @"Items.csv";
            using var sr = new StreamReader(fileName);
            using var csvReader = new CsvReader(sr, CultureInfo.InvariantCulture);
            csvReader.Configuration.RegisterClassMap<ItemMap>();
            var records = csvReader.GetRecords<Item>().ToList();
            return records;
        }
        public void Update(Item item)
        {
            using var stream = File.Open(@"Items.csv", FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.HasHeaderRecord = false;
            csv.WriteRecords((IEnumerable<Item>)item);
            //CsvSerializer cs = new CsvSerializer(csv, CultureInfo.InvariantCulture);
        }
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
