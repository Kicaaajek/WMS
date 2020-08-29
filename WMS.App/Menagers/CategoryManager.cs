using System;
using System.Collections.Generic;
using System.Text;
using WMS.App.Concrete;

namespace WMS.App.Menagers
{
    class CategoryManager
    {
        private CategoryService _categoryService;
        public CategoryManager()
        {
            _categoryService = new CategoryService();
        }
    }
}
