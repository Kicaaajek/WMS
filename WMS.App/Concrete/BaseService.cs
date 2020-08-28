using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.App.Abstract;
using WMS.Domain;
using WMS.Domain.Common;

namespace WMS.App.Concrete
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; } 
        public List<T> Categories { get; set; }
        public BaseService()
        {
            Items = new List<T>();
            Categories = new List<T>();
        }
        
        public void AddItem(T item)
        {
            Items.Add(item);
        }
        public void AddCategory( T category)
        {
            Categories.Add(category);
        }
        public List<T> GetAllItems()
        {
            return Items;
        }
        public List<T> GetAllCategories()
        {
            return Categories;
        }
        public int GetLastId()
        {
            int lastId;
            if(Items.Any())
            {
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }
        public int GetLastCategoryId()
        {
            int lastId;
            if (Categories.Any())
            {
                lastId = Categories.OrderBy(p => p.Id).LastOrDefault().Id;
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
        public void RemoveCategory(T category)
        {
            Categories.Remove(category);
        }
        public T GetItemById(int id)
        {
            var entity = Items.FirstOrDefault(p => p.Id == id);
            return entity;
        }
        public T GetCategoryById(int id)
        {
            var entity = Categories.FirstOrDefault(p => p.Id == id);
            return entity;
        }
        /*public T GetItemByName(string name)
        {
            var entity = Items.FirstOrDefault(p => p.Name == name);
            return entity;
        }*/
    }
}
