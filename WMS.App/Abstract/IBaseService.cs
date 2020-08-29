using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.App.Abstract
{
    public interface IBaseService<T>
    {
        List<T> Items { get; set; }
        List<T> GetAllItems();
        void AddItem(T item);
        void RemoveItem(T item);
        int GetLastId();
        T GetItemById(int id);
    }
}
