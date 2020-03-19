using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model.Entity
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public ObservableCollection<Product> Products { get; set; }
    }
}
