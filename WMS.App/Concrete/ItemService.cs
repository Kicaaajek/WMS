using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using WMS.App.Concrete;
using WMS.Domain;

namespace WMS.App
{
    public class ItemService : BaseService<Item>
    {
        private List<Item> listOfItems = new List<Item>();
        public bool Existed(string nameItem)
        {
            bool beExist = listOfItems.Exists(Item => Item.Name == nameItem);
            return beExist;
        }
       /*public Item GetItemByName(string nameItem)
        {
            
            foreach(var it in listOfItems)
            {
                if(it.Name==nameItem)
                {
                    return it;
                }
            }
            
        }*/
            
    }
}
