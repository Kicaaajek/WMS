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
        public void ShowCategories()
        {
            foreach (var category in GetAllItems())
            {
                Console.WriteLine($"{category.Id}. {category.CategoryName}");
            }
        }
        
    }
}
