using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.App.Abstract
{
    public interface IItem
    {
        int Id { get; }
        string Name { get; set; }
        int Quantity { get; set; }
        bool OnStock { get; set; }
        void IsOnStock();
        void IsLow();
    }
}
