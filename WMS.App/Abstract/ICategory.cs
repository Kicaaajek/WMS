using System;
using System.Collections.Generic;
using System.Text;

namespace WMS.App
{
    public interface ICategory
    {
        int CategoryId { get; }
        string CategoryName { get; set; }
    }
}
