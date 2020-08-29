using System;
using System.Collections.Generic;
using System.Text;
using WMS.App.Concrete;

namespace WMS.App.Menagers
{
    public class MenuManager
    {
        private MenuService _menuService;
        public MenuManager()
        {
            _menuService = new MenuService();
        }
        public void ShowMenu()
        {
            foreach (var m in _menuService.GetAllItems())
            {
                Console.WriteLine($"{m.Id}. {m.Name}");
            }
        }
    }
}
