using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.App.Concrete
{
    public class CategoryService: BaseService<Category>
    {
        //private List<Category> listOfCategories = new List<Category>();
        
        public bool Existed(string nameCat)
        {
            bool beExistCategory = Categories.Exists(p => p.CategoryName == nameCat);
            return beExistCategory;
        }
        public void ShowCategories()
        {
            foreach (var category in GetAllCategories())
            {
                Console.WriteLine(category);
            }
        }
        
    }
}
