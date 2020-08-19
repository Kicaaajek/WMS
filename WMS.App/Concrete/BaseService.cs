﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.App.Abstract;
using WMS.Domain.Common;

namespace WMS.App.Concrete
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; } 
        public BaseService()
        {
            Items = new List<T>();
        }
        public int AddItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public List<T> GetAllItems()
        {
            return Items;
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

        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public T GetItemById(int id)
        {
            var entity = Items.FirstOrDefault(p => p.Id == id);
            return entity;
        }
    }
}