using System;
using System.Collections.Generic;
using System.Text;
using WMS.Domain.Entity;
using WMS.App;

namespace WMS.App.Concrete
{
    public class MenuService : BaseService<Menu>
    {
        public MenuService()
        {
            Initialize();
        }

        public List<Menu> GetMenu()
        {
            List<Menu> menus = new List<Menu>();
            foreach(var menu in Items)
            {
                    menus.Add(menu);
            }
            return menus;
        }

        private void Initialize()
        {
            AddItem(new Menu(1, "Add item"));
            AddItem(new Menu(2, "Remove item"));
            AddItem(new Menu(3, "Check availability of item"));
            AddItem(new Menu(4, "Check which items are run out"));
            AddItem(new Menu(5, "Show list of items"));
            AddItem(new Menu(6, "Show list of categories"));
            AddItem(new Menu(7, "Close app"));
        }
    }
}