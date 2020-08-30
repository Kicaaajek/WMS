using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.App.Concrete
{
    public class CategoryService: BaseService<Category>
    {
        public bool Existed(string nameCat)
        {
            bool beExistCategory = Items.Exists(p => p.CategoryName == nameCat);
            return beExistCategory;
        }
        public int GetCatId(string nameCat)
        {
            int idCat=0;
            foreach (var c in Items)
            {
                if (c.CategoryName == nameCat)
                {
                    idCat = c.Id;
                }
            }
            return idCat;
        }
        public string[] GetAll()
        {
            string[] name = new string[Items.Count];
            int a = 0;
            foreach (var i in Items)
            {
                name[a] = i.CategoryName;
                a++;
            }
            return name;
        }
    }
}
