using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WMS.App.Concrete;
using Xunit;

namespace WMS.Tests
{
    public class CategoryServiceTests
    {
        public CategoryService MakeList()
        {
            Category category = new Category(1, "Vegetables");
            Category category2 = new Category(2, "Fruits");
            Category category3 = new Category(3, "Meats");
            CategoryService categoryService = new CategoryService();
            categoryService.AddItem(category);
            categoryService.AddItem(category2);
            categoryService.AddItem(category3);
            return categoryService;
        }
        [Fact]
        public void IfExisted()
        {
            var categoryService = MakeList();
            bool exist = categoryService.Existed("Meats");
            Assert.True(exist);
        }

        [Fact]
        public void IfGetCat()
        {
            var categoryService = MakeList();
            int number = categoryService.GetCatId("Fruits");
            Assert.Equal(2, number);
        }

        [Fact]
        public void IfGetAll()
        {
            var categoryService = MakeList();
            var categories = categoryService.GetAll().ToList();
            Assert.Equal(3, categories.Count);
        }

    }
}
