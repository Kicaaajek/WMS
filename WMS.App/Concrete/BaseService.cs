using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using WMS.App.Abstract;
using WMS.Domain;
using WMS.Domain.Common;

namespace WMS.App.Concrete
{
    public abstract class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected List<T> Items { get; set; }
        public BaseService()
        {
            Items = new List<T>();
        }
        public void AddItem(T item)
        {
            Items.Add(item);
        }
        public List<T> GetAllItems()
        {
            return Items;
        }
        public int GetLastId()
        {
            int lastId;
            if (Items.Any())
            {
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }
        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }
        public T GetItemById(int id)
        {
            var entity = Items.FirstOrDefault(p => p.Id == id);
            return entity;
        }
        public List<T> Load(string name, string path)
        {
            XmlRootAttribute root = new XmlRootAttribute
            {
                ElementName = name,
                IsNullable = true
            };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>), root);
            if (!File.Exists(path))
            {
                Items = new List<T>();
            }
            else
            {
                string output = File.ReadAllText(path);
                StringReader stringReader = new StringReader(output);
                Items = (List<T>)xmlSerializer.Deserialize(stringReader);
            }
            return Items;
        }
        public void AddNewItem(T item, string name, string path)
        {
            XmlRootAttribute root = new XmlRootAttribute
            {
                ElementName = name,
                IsNullable = true
            };
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>), root);
            using StreamWriter streamWriter = new StreamWriter(path);
            xmlSerializer.Serialize(streamWriter, Items);
        }
    }
}
