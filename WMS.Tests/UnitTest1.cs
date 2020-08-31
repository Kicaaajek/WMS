using Microsoft.VisualBasic;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WMS.App;
using WMS.App.Abstract;
using WMS.App.Concrete;
using WMS.App.Menagers;
using WMS.Domain;
using Xunit;

namespace WMS.Tests
{
    public class UnitTest1
    {
        

        public ItemService MakeList()
        {
            //Arrange
            Item item = new Item(1, "Fruits", 1, "Apples", 6);
            Item item2 = new Item(1, "Fruits", 2, "Plums", 2);
            Item item3 = new Item(1, "Fruits", 3, "Pineapples", 6);
            Item item4 = new Item(2, "Vegetables", 1, "Onions", 12);
            Item item5 = new Item(2, "Vegetables", 2, "Broccolies", 1);
            ItemService _itemService = new ItemService();
            IBaseService<Category> categoryService = new CategoryService();
            _itemService.AddItem(item);
            _itemService.AddItem(item2);
            _itemService.AddItem(item3);
            _itemService.AddItem(item4);
            _itemService.AddItem(item5);
            return _itemService;
        }

        [Fact]
        public void IfItemExisted()
        {
            ItemService itemService = MakeList();
            var exist= itemService.Existed("Apples");
            Assert.True(exist);
        }

        [Fact]
        public void IfGetQuantity()
        {
            ItemService itemService = MakeList();
            int quantity=itemService.GetQuantity("Apples");
            Assert.Equal(6,quantity);
        }

        [Fact]
        public void IfChangeQuantity()
        {
            ItemService itemService = new ItemService();
            //int number = itemService.GetQuantity("Pineapples");
            itemService.AddQuantity("Pineapples", 4);
            int quantity= itemService.GetQuantity("Pineapples");
            Assert.Equal(10, quantity);
        }

        [Fact]
        public void IfGetAll()
        {
            ItemService itemService = new ItemService();
            //List<Item> Items = new List<Item>();
            var items = itemService.GetAll().ToList();
            //Assert.Equal(itemService, items);
        }
    }
}
