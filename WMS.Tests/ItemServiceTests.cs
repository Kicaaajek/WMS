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
    public class ItemServiceTests
    {


        public ItemService MakeList()
        {
            //Arrange
            Item item = new Item(1, "Fruits", 1, "Apples", 6);
            Item item2 = new Item(1, "Fruits", 2, "Plums", 2);
            Item item3 = new Item(1, "Fruits", 3, "Pineapples", 6);
            Item item4 = new Item(2, "Vegetables", 4, "Onions", 12);
            Item item5 = new Item(2, "Vegetables", 5, "Broccolies", 1);
            ItemService _itemService = new ItemService();
            /*var mock = new Mock< IBaseService<Item>>();
            mock.Setup(s => s.GetItemById(1)).Returns(item);
            mock.Setup(s => s.GetItemById(2)).Returns(item2);
            mock.Setup(s => s.GetItemById(3)).Returns(item3);
            mock.Setup(s => s.GetItemById(4)).Returns(item4);
            mock.Setup(s => s.GetItemById(5)).Returns(item5);
            return mock;*/
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
            var exist = itemService.Existed("Apples");
            Assert.True(exist);
        }

        [Fact]
        public void IfGetQuantity()
        {
            ItemService itemService = MakeList();
            int quantity = itemService.GetQuantity("Apples");
            Assert.Equal(6, quantity);
        }

        [Fact]
        public void IfChangeQuantity()
        {
            ItemService itemService = MakeList();
            //int number = itemService.GetQuantity("Pineapples");
            itemService.AddQuantity("Pineapples", 4);
            int quantity = itemService.GetQuantity("Pineapples");
            Assert.Equal(10, quantity);
        }

        [Fact]
        public void IfGetAll()
        {
            ItemService itemService = MakeList();
            //List<Item> Items = new List<Item>();
            var items = itemService.GetAll().ToList();
            Assert.Equal(5, items.Count);
        }

        [Fact]
        public void IfRemoveQuantity()
        {
            ItemService itemService = MakeList();
            itemService.RemoveQuantity("Onions", 4);
            int quantity = itemService.GetQuantity("Onions");
            Assert.Equal(8, quantity);
        }

        [Fact]
        public void IfIsLow()
        {
            ItemService itemService = MakeList();
            List<Item> items= itemService.IsLow();
            Assert.Equal(2, items.Count);
        }
    }
}
