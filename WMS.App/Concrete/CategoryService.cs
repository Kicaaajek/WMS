using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.App.Concrete
{
    public class CategoryService: BaseService<Category>
    {
        private List<Category> listOfCategories = new List<Category>();
        public bool Existed(string nameCat)
        {
            bool beExistCategory = listOfCategories.Exists(Category => Category.CategoryName == nameCat);
            return beExistCategory;
        }
    }
}
