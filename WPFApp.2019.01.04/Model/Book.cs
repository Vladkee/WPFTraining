using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApp._2019._01._04.Model
{
    public class Book : EntityBase
    {
        public string Title { get; set; }

        public DateTime Date { get; set; }

        public decimal Cost { get; set; }

        public Book(int id, string title, DateTime date, decimal cost)
        {
            this.Title = title;
            this.Date = date;
            this.Cost = cost;
        }

        public Book()
        {

        }
    }
}
